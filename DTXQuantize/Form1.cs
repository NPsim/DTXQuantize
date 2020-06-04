using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;

namespace DTXQuantize {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            WriteConsoleLine("DTXQuantize 1.0 Loaded");
        }

        private void WriteConsoleLine(string Text, string Prefix = "") {
            string TimeStamp = DateTime.Now.ToString("HH:mm:ss");
            if (Prefix.Length == 0)
                ConsoleRichBox.Text += '[' + TimeStamp + "] - " + Text + '\n';
            else
                ConsoleRichBox.Text += '[' + Prefix + "] - " + Text + '\n';

            ConsoleRichBox.Focus();
            ConsoleRichBox.Select(ConsoleRichBox.Text.Length, 0);
        }

        private readonly char[] Base36Digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private string Base10ToBase36(int Value) {
            if (Value <= 0) // We don't care about negative numbers here
                return "00";
            string Result = "";
            while (Value > 0) {
                Result = Base36Digits[Value % 36] + Result;
                Value /= 36; // Divide by 36 then Floor
            }
            return Result;
        }

        // 1s = 60 BPM
        // 0.5s = 120 BPM
        private double PeriodSecondToBPM(double Period) {
            return 60 / Period;
        }

        // Extends double rounding to place values left of the decimal
        private double ExtendedDoubleRound(double Value, int Digits) { // Digits = 2 rounds to 0.01, Digits = -2 rounds to 10
            if (Digits >= 0) {
                return Math.Round(Value, Digits);
            }
            else {
                Value *= Math.Pow(10, Digits);
                double Multiplier = Math.Pow(10, Math.Abs(Digits));
                return Math.Round(Value, 0) * Multiplier;
            }
        }

        private double SampleIndexToSeekTime(int SampleIndex, int SampleRateHz) {
            double Time = (double)SampleIndex / (double)SampleRateHz;
            Time += double.Parse(BeatOffsetTextBox.Text) / 1000; // BeatOffsetTextBox.Text given in milliSeconds
            return Time >= 0 ? Time : 0;
        }

        private List<double> GenerateBeatList(List<float> AmplitudeList, WaveFormat Format) {
            List<double> BeatList = new List<double>();
            double Threshold = double.Parse(ThresholdTextBox.Text);
            Double PreviousBeatTime = -1;
            for (int SampleIndex = 0; SampleIndex < AmplitudeList.Count; SampleIndex++) {
                float Amplitude = AmplitudeList[SampleIndex];

                // Find first beat
                if (Amplitude >= Threshold) {
                    double SampleBeatTime = SampleIndexToSeekTime(SampleIndex, Format.SampleRate);
                    if (PreviousBeatTime > 0) {
                        BeatList.Add(SampleBeatTime);
                        int SamplesToJump = (int)Math.Ceiling(Format.SampleRate * double.Parse(SampleLengthTextBox.Text) / 1000000);
                        SampleIndex += (int)Math.Ceiling(Format.SampleRate * double.Parse(SampleLengthTextBox.Text) / 1000000); // Jump ahead click length
                    }
                    PreviousBeatTime = SampleBeatTime;
                }
            }
            WriteConsoleLine("Found " + BeatList.Count + " beats.");
            return BeatList;
        }

        private List<double> GenerateBPMList(List<double> BeatList) {
            int BPMRound = int.Parse(BPMRoundTextBox.Text);
            List<Double> BPMList = new List<double>();
            for (int BeatIndex = 0; BeatIndex < BeatList.Count - 1; BeatIndex++) {
                double PeriodToNextBeat = BeatList[BeatIndex + 1] - BeatList[BeatIndex];
                BPMList.Add(ExtendedDoubleRound(PeriodSecondToBPM(PeriodToNextBeat), BPMRound));
            }
            return BPMList;
        }

        private void GenerateDTX(DTXSimFile SimFile) {
            StreamWriter Writer = new StreamWriter(SimFile.SaveFilePath);
            Writer.WriteLine("#00002: " + (SimFile.BeatsPerBar / 4) + " ;" + SimFile.BeatsPerBar + " beats per bar"); // Bar 0 Time Signature

            // Build BPM Table
            Dictionary<double, string> BPMLookup = new Dictionary<double, string>(); // <Tempo Value, BPM Chip ID>
            foreach (double BPM in SimFile.BPMList) {
                if (!BPMLookup.ContainsKey(BPM)) {
                    string Index36 = Base10ToBase36(BPMLookup.Keys.Count + 1).PadLeft(2, '0');
                    BPMLookup[BPM] = Index36;
                    Writer.WriteLine("#BPM" + Index36 + ": " + BPM);
                }
            }

            // Write DTX SimFile
            int Bar = 1;
            int PositionInBar = 1; // Always less than or equal to SimFile.BeatsPerBar
            string PreviousBPMChip = "";
            int ChipCounter = 0;
            foreach (double BPM in SimFile.BPMList) {

                // Place BPM Chip
                if (PositionInBar == 1) {
                    Writer.Write("#" + Bar.ToString("000") + "08: "); // Write BPM Chip prefix and bar number
                }
                if (PreviousBPMChip != BPMLookup[BPM] || (Bar == 1 && PositionInBar == 1)) {
                    Writer.Write(BPMLookup[BPM]); // Write the actual BPM Chip here
                    ChipCounter++;
                }
                else {
                    Writer.Write("00"); // Don't put two of the same BPM chips in a row
                }
                PreviousBPMChip = BPMLookup[BPM];

                // Move to next beat
                PositionInBar++;
                if (PositionInBar > SimFile.BeatsPerBar) { // Move to next bar
                    Writer.Write('\n');
                    PositionInBar = 1;
                    Bar++;
                }
            }

            WriteConsoleLine("Wrote " + ChipCounter + " BPM chips.");

            // Fill rest of last bar with null
            if (PositionInBar != 1) {
                while (PositionInBar <= SimFile.BeatsPerBar) {
                    Writer.Write("00");
                    PositionInBar++;
                }
                Writer.Write('\n');
            }
            Writer.Close();

            WriteConsoleLine("Exported to " + SimFile.SaveFilePath);
        }

        private void ExportSnippetButton_Click(object sender, EventArgs e) {
            try { // My programs never crash! xd

                // Get Save Path
                SaveFileDialog Dialog = new SaveFileDialog {
                    Filter = "DTX SimFiles (*.dtx)|*.dtx|All files (*.*)|*.*"
                };
                Dialog.ShowDialog();

                // Generate Amplitude List
                List<float> AmplitudeList = new List<float>();
                AudioFileReader Wave = new AudioFileReader(LoadFileTextBox.Text);
                float[] Buffer = new float[1024];
                int SamplesRead = -1;

                while (SamplesRead != 0) {
                    SamplesRead = Wave.Read(Buffer, 0, 1024);
                    foreach (float Amplitude in Buffer) {
                        AmplitudeList.Add(Amplitude);
                    }
                }

                // Generate Beat Time List
                List<double> BeatList = GenerateBeatList(AmplitudeList, Wave.WaveFormat);

                // Generate BPM List
                List<double> BPMList = GenerateBPMList(BeatList);

                // Generate DTX Simfile
                DTXSimFile SimFile = new DTXSimFile {
                    BPMList = BPMList,
                    BeatsPerBar = double.Parse(BarLengthTextbox.Text),
                    SaveFilePath = Dialog.FileName
                };
                GenerateDTX(SimFile);
            }
            catch (Exception ex) {
                WriteConsoleLine(ex.Message, DateTime.Now.ToString("HH:mm:ss") + " Error");
            }
        }

        private void LoadFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.ShowDialog();
            LoadFileTextBox.Text = Dialog.FileName;
            LoadFileTextBox.Focus();
            LoadFileTextBox.Select(LoadFileTextBox.Text.Length, 0);
            if (LoadFileTextBox.Text.Length > 0)
                WriteConsoleLine("Loaded " + Dialog.FileName);
        }

        private void LoadFileHint_Click(object sender, EventArgs e) { // Load Click Track
            string Message = string.Join(
                Environment.NewLine,
                "Select a click track audio file.",
                "Best used with 'WAV (Microsoft) signed 16bit PCM' at any Sample Rate.",
                "Untested with other audio formats",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Load Click Track",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Loading-a-Click-Track"
            );
        }

        private void ThresholdHint_Click(object sender, EventArgs e) { // Amplitude Threshold
            string Message = string.Join(
                Environment.NewLine,
                "Specify what audio level marks a beat",
                "Value must be a number, typically between 1.0 and 0.01",
                "Default: 0.10",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Amplitude Threshold",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Amplitude-Threshold"
            );
        }

        private void BarLengthHint_Click(object sender, EventArgs e) { // Beats per Bar
            string Message = string.Join(
                Environment.NewLine,
                "Specify how long a measure or bar is",
                "Value must be a number, accepts decimals",
                "Default: 4",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Beats per Bar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Beats-per-Bar"
            );
        }

        private void BPMRoundHint_Click(object sender, EventArgs e) { // Round BPM
            string Message = string.Join(
                Environment.NewLine,
                "Specify how precise each BPM chip's value is",
                "Value must be a whole number less than or equal to 15",
                "Value may be negative to round left side of decimal",
                "Default: 3",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Round BPM",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Round-BPM"
            );
        }

        private void BeatOffsetHint_Click(object sender, EventArgs e) { // Beat Offset
            string Message = string.Join(
                Environment.NewLine,
                "Value offsets beat markers in milliseconds",
                "Value must be a number, accepts decimals",
                "Default: -5",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Beat Offset",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Beat-Offset"
            );
        }

        private void SampleLengthHint_Click(object sender, EventArgs e) { // Click Length
            string Message = string.Join(
                Environment.NewLine,
                "Length of a click in the click track in microseconds",
                "Value must be a number, accepts decimals",
                "Note: 1,000μs = 1ms    0.001ms = 1μs",
                "Default: 10000",
                "",
                "More information at Help below"
            );
            MessageBox.Show(
                Message,
                "Click Length",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                0,
                "https://github.com/NPsim/DTXQuantize/wiki/Click-Length"
            );
        }
    }

    public class DTXSimFile {
        public List<double> BPMList;
        public double BeatsPerBar;
        public string SaveFilePath;
    }
}
