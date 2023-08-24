using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

namespace FileTimeChanger
{
    public partial class Form_Main : Form
    {
        string FilePath;
        FileStream FileHandle;
        DateTime FileCreation;
        DateTime FileLastAccessed;
        DateTime FileLastChanged;

        private void Reset()
        {
            FilePath = "";
            Helper.CloseFileSafely(ref FileHandle);
            FileCreation = Use_UTC.Checked ? DateTime.UtcNow : DateTime.Now;
            FileLastAccessed = FileCreation;
            FileLastChanged = FileCreation;

            Picker_Creation.Value = FileCreation;
            Picker_LastAccessed.Value = Picker_Creation.Value;
            Picker_LastChanged.Value = Picker_Creation.Value;

            Use_UTC.Enabled = false;
            Close_File.Enabled = false;
            Apply.Enabled = false;
            Picker_Creation.Enabled = false;
            Picker_LastAccessed.Enabled = false;
            Picker_LastChanged.Enabled = false;
        }

        private void RefreshUTCDepentandValues()
        {
            FileCreation = Use_UTC.Checked ? File.GetCreationTimeUtc(FilePath) : File.GetCreationTime(FilePath);
            FileLastAccessed = Use_UTC.Checked ? File.GetLastAccessTimeUtc(FilePath) : File.GetLastAccessTime(FilePath);
            FileLastChanged = Use_UTC.Checked ? File.GetLastWriteTimeUtc(FilePath) : File.GetLastWriteTime(FilePath);

            Picker_Creation.Value = FileCreation;
            Picker_LastAccessed.Value = FileLastAccessed;
            Picker_LastChanged.Value = FileLastChanged;
        }

        public Form_Main()
        {
            InitializeComponent();
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Reset();
            Use_UTC.Text = "UTC (" + (DateTime.UtcNow - DateTime.Now).TotalHours + "h)";
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Helper.CloseFileSafely(ref FileHandle);
        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                DereferenceLinks = false,
                Multiselect = false,
                Filter = "All Files|*.*|Audio|*.aif;*.cda;*.mid;*.midi;*.mp3;*.mpa;*.ogg;*.wav;*.wma;*.wpl|Compressed|*.7z;*.arj;*.deb;*.pkg;*.rar;*.rpm;*.tag.gz;*.z;*.zip|Disc|*.bin;*.dmg;*.iso;*.toast;*.vcd|Data(base)|*.csv;*.dat;*.db;*.dbf;*.log;*.mdb;*.sav;*.sql;*.tar;*.xml|Executables|*.apk;*.bat;*.cmd;*.bin;*.cgi;*.pl;*.com;*.exe;*.gadget;*.jar;*.py;*.wsf|Fonts|*.fnt;*.fon;*.otf;*.ttf|Images|*.ai;*.bmp;*.gif;*.ico;*.jpeg;*.jpg;*.png;*.ps;*.psd;*.svg;*.tif;*.tiff|Web|*.asp;*.aspx;*.cer;*.cfm;*.cgi;*.pl;*.css;*.htm;*.html;*.js;*.jsp;*.part;*.php;*.py;*.rss;*.xhtml|Presentations|*.key;*.odp;*.pps;*.ppt;*.pptx|Programming|*.c;*.cpp;*.h;*.hpp;*.class;*.java;*.sh;*.swift;*.vb|Spreadsheets|*.ods;*.xlr;*.xls;*.xlsx;*.xlt;*.xlm|System|*.bak;*.cab;*.cfg;*.cpl;*.cur;*.dll;*.dmp;*.drv;*.icns;*.ico;*.ini;*.lnk;*.msi;*.tmp|Videos|*.3g2;*.3gp;*.avi;*.flv;*.h264;*.m4v;*.mkv;*.mov;*.mp4;*.mpg;*.mpeg;*.rm;*.swf;*.vob;*.wmv|Word processors|*.doc;*.docx;*.odt;*.pdf;*.rtf;*.tex;*.txt;*.wks;*.wps;*.wpd"
            };

            if (OFD.ShowDialog() != DialogResult.OK) { return; }; //No (new) File selected

            while(!Helper.IsFileReady(OFD.FileName))
            {
                DialogResult result = MessageBox.Show(
                    "The selected File is currently being used by another program.\r\nIf the issue has been resolved click retry.",
                    "File is in use",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Exclamation);
                if (result != DialogResult.Retry) { return; };
            };

            //Open File and display Dates
            FilePath = OFD.FileName;
            FileHandle = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

            RefreshUTCDepentandValues();

            //Activate Controls
            Use_UTC.Enabled = true;
            Close_File.Enabled = true;
            Picker_Creation.Enabled = true;
            Picker_LastAccessed.Enabled = true;
            Picker_LastChanged.Enabled = true;
        }

        private void Close_File_Click(object sender, EventArgs e)
        {
            Helper.CloseFileSafely(ref FileHandle);
            Reset();
        }


        private void Use_UTC_CheckedChanged(object sender, EventArgs e)
        {
            RefreshUTCDepentandValues();
        }
        private void Picker_Creation_ValueChanged(object sender, EventArgs e)
        {
            DT_Picker_Main(Picker_Creation, "Creation");
        }
        private void Picker_LastChanged_ValueChanged(object sender, EventArgs e)
        {
            DT_Picker_Main(Picker_LastChanged, "LastChanged");
        }
        private void Picker_LastAccessed_ValueChanged(object sender, EventArgs e)
        {
            DT_Picker_Main(Picker_LastAccessed, "LastAccessed");
        }
        private void DT_Picker_Main(DateTimePicker sender, string PickerType)
        {
            DateTime ToCompare = DateTime.MinValue;

            switch (PickerType)
            {
                case "Creation":
                    ToCompare = FileCreation;
                    break;
                case "LastChanged":
                    ToCompare = FileLastChanged;
                    break;
                case "LastAccessed":
                    ToCompare = FileLastAccessed;
                    break;
            }

            if (sender.Value.Ticks == ToCompare.Ticks)
            {
                sender.Font = new Font(sender.Font, FontStyle.Regular);

                if(FileCreation.Ticks == Picker_Creation.Value.Ticks &&
                   FileLastChanged.Ticks == Picker_LastChanged.Value.Ticks &&
                   FileLastAccessed.Ticks == Picker_LastAccessed.Value.Ticks)
                {
                    Apply.Enabled = false;
                }
            }
            else
            {
                sender.Font = new Font(sender.Font, FontStyle.Italic);
                Apply.Enabled = true;
            };
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            Apply.Enabled = false;
            FileHandle.Close();

            if (Picker_Creation.Value != FileCreation)
            {
                if (Use_UTC.Checked) { File.SetCreationTimeUtc(FilePath, Picker_Creation.Value); }
                                else { File.SetCreationTime(FilePath, Picker_Creation.Value); };
            }
            if (Picker_LastAccessed.Value != FileLastAccessed)
            {
                if (Use_UTC.Checked) { File.SetLastAccessTimeUtc(FilePath, Picker_LastAccessed.Value); }
                                else { File.SetLastAccessTime(FilePath, Picker_LastAccessed.Value); };
            }
            if (Picker_LastChanged.Value != FileLastChanged)
            {
                if (Use_UTC.Checked) { File.SetLastWriteTimeUtc(FilePath, Picker_LastChanged.Value); }
                                else { File.SetLastWriteTime(FilePath, Picker_LastChanged.Value); };
            }

            FileHandle = File.Open(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
    }

    class Helper
    {
        public static bool IsFileReady(string filename)
        {
            try
            {
                FileStream stream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                stream.Close();
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public static bool HasAttribute(FileAttributes src, FileAttributes has)
        {
            return (src & has) == has;
        }
        public static FileAttributes RemoveAttribute(FileAttributes src, FileAttributes del)
        {
            return src & ~del;
        }
        public static FileAttributes AddAttribute(FileAttributes src, FileAttributes add)
        {
            return src | add;
        }

        public static void CloseFileSafely(ref FileStream stream)
        {
            if (stream != null)
            {
                stream.Close(); stream = null;
            };
        }
    }
}