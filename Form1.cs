using MaterialSkin.Controls;
using Gma.System.MouseKeyHook;
using OpenapiDemo;
using System;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using MaterialSkin;
using System.Drawing.Text;

namespace ClipboardTranslator
{

    public partial class Form1 : MaterialForm
    {
        private void UpdateLanguageComboBox(string selectedTranslationEngine)
        {
            // ʹ��ѡ��ķ��������Ӧ���ֵ��ȡ�����б�
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                materialComboBox1.Items.Clear();
                materialComboBox3.Items.Clear();
            // �������б����
                materialComboBox1.Items.AddRange(languageMapping.Keys.ToArray());
                materialComboBox3.Items.AddRange(languageMapping.Keys.ToArray());
            }
            else
            {
                //MessageBox.Show("δ�ҵ���Ӧ�ķ�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //�����Ǿ���ChatGPT���ɵ�
            }
        }

        private Dictionary<string, Dictionary<string, string>> translationEngineMappings = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "�е�����",
                new Dictionary<string, string>
                {
                    {"�Զ�ѡ��", "auto"},
                    {"��������", "zh-CHS"},
                    {"��������", "zh-CHT"},
                    {"Ӣ��", "en"},
                    {"����", "ja"},
                    {"����", "ru"},
                    {"��������", "pt"},
                    {"�������", "it"},
                    {"����", "de"},
                    {"��������", "es"},
                    {"����", "fr"},
                    {"����", "ko"},
                    {"����", "yue"},
                    {"��������", "ar"},
                    {"ӡ����������", "id"},
                    {"������", "nl"},
                    {"̩��", "th"},
                    {"Խ����", "vi"},
                    {"�ϷǺ�����", "af"},
                    {"��ķ������", "am"},
                    {"�����ݽ���", "az"},
                    {"�׶���˹��", "be"},
                    {"����������", "bg"},
                    {"�ϼ�����", "bn"},
                    {"��˹������", "bs"},
                    {"��̩¡��", "ca"},
                    {"������", "ceb"},
                    {"��������", "co"},
                    {"�ݿ���", "cs"},
                    {"����ʿ��", "cy"},
                    {"������", "da"},
                    {"ϣ����", "el"},
                    {"������", "eo"},
                    {"��ɳ������", "et"},
                    {"��˹����", "eu"},
                    {"��˹��", "fa"},
                    {"������", "fi"},
                    {"쳼���", "fj"},
                    {"��������", "fy"},
                    {"��������", "ga"},
                    {"�ո����Ƕ���", "gd"},
                    {"����������", "gl"},
                    {"�ż�������", "gu"},
                    {"������", "ha"},
                    {"��������", "haw"},
                    {"ϣ������", "he"},
                    {"ӡ����", "hi"},
                    {"���޵�����", "hr"},
                    {"���ؿ���¶���", "ht"},
                    {"��������", "hu"},
                    {"����������", "hy"},
                    {"������", "ig"},
                    {"������", "is"},
                    {"צ����", "jw"},
                    {"��³������", "ka"},
                    {"��������", "kk"},
                    {"������", "km"},
                    {"���ɴ���", "kn"},
                    {"�������", "ku"},
                    {"�¶�������", "ky"},
                    {"������", "la"},
                    {"¬ɭ����", "lb"},
                    {"������", "lo"},
                    {"��������", "lt"},
                    {"����ά����", "lv"},
                    {"�����ʲ��", "mg"},
                    {"ë����", "mi"},
                    {"�������", "mk"},
                    {"��������ķ��", "ml"},
                    {"�ɹ���", "mn"},
                    {"��������", "mr"},
                    {"������", "ms"},
                    {"�������", "mt"},
                    {"������", "mww"},
                    {"�����", "my"},
                    {"�Ჴ����", "ne"},
                    {"Ų����", "no"},
                    {"��������", "ny"},
                    {"�������ް�������", "otq"},
                    {"��������", "pa"},
                    {"������", "pl"},
                    {"��ʲͼ��", "ps"},
                    {"����������", "ro"},
                    {"�ŵ���", "sd"},
                    {"ɮ٤����", "si"},
                    {"˹�工����", "sk"},
                    {"˹����������", "sl"},
                    {"��Ħ����", "sm"},
                    {"������", "sn"},
                    {"��������", "so"},
                    {"������������", "sq"},
                    {"����ά����(�������)", "sr-Cyrl"},
                    {"����ά����(������)", "sr-Latn"},
                    {"��������", "st"},
                    {"������", "su"},
                    {"�����", "sv"},
                    {"˹��ϣ����", "sw"},
                    {"̩�׶���", "ta"},
                    {"̩¬����", "te"},
                    {"��������", "tg"},
                    {"���ɱ���", "tl"},
                    {"���ֹ���", "tlh"},
                    {"������", "to"},
                    {"��������", "tr"},
                    {"��ϣ����", "ty"},
                    {"�ڿ�����", "uk"},
                    {"�ڶ�����", "ur"},
                    {"���ȱ����", "uz"},
                    {"�Ϸǿ�����", "xh"},
                    {"�������", "yi"},
                    {"Լ³����", "yo"},
                    {"�ȿ�̹������", "yua"},
                    {"�Ϸ���³��", "zu"},
                    // ��Ӹ�������...
                }
            }
            //{
                //"�ٶȷ���",
                //new Dictionary<string, string>
                //{
                    
                    // �������
                //}
            //},
            // ��Ӹ��෭������
        };

        // ���� Windows API ����
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        private IntPtr handle; // ���ڴ洢������

        private IKeyboardMouseEvents _globalKeyboardHook;
        private ApiCredentialsManager credentialsManager = new ApiCredentialsManager();
        private void SaveApiCredentials()
        {
            string apiAccount = materialTextBox1.Text;
            string apiKey = materialTextBox2.Text;
            credentialsManager.SaveApiCredentials(apiAccount, apiKey);
        }

        private void LoadApiCredentials()
        {
            // �ڴ������ʱ��ȡ API �˺ź���Կ
            (string apiAccount, string apiKey) = credentialsManager.ReadApiCredentials();

            if (!string.IsNullOrEmpty(apiAccount) && !string.IsNullOrEmpty(apiKey))
            {
                // ������ʹ�� apiAccount �� apiKey ������������
                materialTextBox1.Text = apiAccount;
                materialTextBox2.Text = apiKey;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // �ڴ������ʱ���ü��������
            LoadApiCredentials();
            FormClosed += Form1_FormClosed;  //����FormClosed�¼�                                            
            materialComboBox2.Items.AddRange(translationEngineMappings.Keys.ToArray());
            materialComboBox2.SelectedIndex = 0;
            materialComboBox1.SelectedIndexChanged += materialComboBox1_SelectedIndexChanged;
            materialComboBox2.SelectedIndexChanged += materialComboBox2_SelectedIndexChanged;
            materialComboBox3.SelectedIndexChanged += materialComboBox3_SelectedIndexChanged;
            UpdateLanguageComboBox(materialComboBox2.Text);
            materialComboBox1.SelectedIndex = 0;
            materialComboBox3.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _globalKeyboardHook = Hook.GlobalEvents();
            //_globalKeyboardHook.KeyDown += OnKeyUp;
            // ��ȡ������
            handle = this.Handle;
            // ���ü��������
            AddClipboardFormatListener(handle);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _globalKeyboardHook.Dispose();
            SaveApiCredentials();
            RemoveClipboardFormatListener(handle);  // ���ü��������
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_CLIPBOARDUPDATE = 0x031D;

            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (materialSwitch1.Checked)               // ���������ݷ����仯ʱִ��
                {
                    if (!string.Equals(Clipboard.GetText(), materialMultiLineTextBox23.Text) && Clipboard.GetText() != "") //��Ӷ�Clipboard.GetText() != ""���жϿ������û���ͼʱ������
                    {
                        materialMultiLineTextBox21.Text = Clipboard.GetText(); // ��ȡ�������е�����
                        materialMultiLineTextBox22.Text = Translate();
                        readtranslation();

                        if (materialSwitch2.Checked)
                        {
                            Clipboard.SetText(materialMultiLineTextBox23.Text);      // ��󽫽�����õ�������
                        }
                        if (materialSwitch3.Checked)
                        {
                            ClipboardHelper.Paste();
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }
        //private void Clipboard_TextChanged(object sender, EventArgs e)
        //{
        //�ж��Ƿ�����Ctrl+C��ϼ�
        //if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Control && materialSwitch1.Checked)
        //{
        //ִ������Ҫ�Ĵ���
        // materialMultiLineTextBox21.Text = Clipboard.GetText();
        //materialMultiLineTextBox22.Text = Translate();
        //readtranslation();
        //  Invoke(new Action(() => Clipboard.SetText(materialMultiLineTextBox23.Text)));
        //}
        //}
        //ԭ���ü���û�����Ctrl+C�ķ��������� ��ȡ���а����� ������ ���� �������֮ǰ��Ҳ���Ǽ����Ҽ��а�ԭ����1���Ҹ��ơ�2���������ȡ������1
        //���Ժ����ĳ��˼����а����ݱ仯�ķ���

        // ����Ӧ��ID
        //private static string APP_KEY = "";
        //����Ӧ����Կ
        // private static string APP_SECRET = "";
        void readtranslation()
        {
            // ���� materialMultiLineTextBox22.Text ������� JSON ����
            string jsonData = materialMultiLineTextBox22.Text;

            // ��JSON�ַ�������ΪJObject
            JObject json = JObject.Parse(jsonData);

            // ��ȡtranslation�ֶε�ֵ
            JArray translationArray = json["translation"] as JArray;

            // ��������������Ϊ�ַ����������õ� materialMultiLineTextBox23 ��
            if (translationArray != null)
            {
                string translationText = string.Join(Environment.NewLine, translationArray);
                // ���������õ� materialMultiLineTextBox23
                materialMultiLineTextBox23.Text = translationText;
            }
        }
        public string Translate()
        {
            //APP_KEY = form1.materialTextBox1.Text;
            //APP_SECRET = form1.materialTextBox2.Text;
            // ����������
            Dictionary<String, String[]> paramsMap = createRequestParams();
            // ��Ӽ�Ȩ��ز���
            AuthV3Util.addAuthParams(materialTextBox1.Text, materialTextBox2.Text, paramsMap);
            Dictionary<String, String[]> header = new Dictionary<string, string[]>() { { "Content-Type", new String[] { "application/x-www-form-urlencoded" } } };
            // ����api����
            byte[] result = HttpUtil.doPost("https://openapi.youdao.com/api", header, paramsMap, "application/json");
            // ��ӡ���ؽ��
            if (result != null)
            {
                string resStr = System.Text.Encoding.UTF8.GetString(result);
                return resStr;
            }
            else
            {
                return null;
            }

        }

        public Dictionary<String, String[]> createRequestParams()
        {

            // note: �����б����滻Ϊ��Ҫ����Ĳ���
            string q = Clipboard.GetText();
            string from = materialTextBox3.Text;
            string to = materialTextBox4.Text;
            string strict = "false";
            return new Dictionary<string, string[]>() {
                { "q", new string[]{q}},
                {"from", new string[]{from}},
                {"to", new string[]{to}},
                {"strict", new string[]{strict}},
            };
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ��ȡ�û�ѡ��ķ�������
            string selectedTranslationEngine = materialComboBox2.Text;

            // ʹ��ѡ��ķ��������Ӧ���ֵ��ȡ���Դ���
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                // ��ȡ�û�ѡ�������
                string selectedLanguage = materialComboBox1.Text;

                // ʹ���ֵ��ȡ��Ӧ�����Դ���
                if (languageMapping.TryGetValue(selectedLanguage, out string languageCodeFrom))
                {
                    materialTextBox3.Text = languageCodeFrom;
                }
                else
                {
                    //MessageBox.Show("δ�ҵ���Ӧ�����Դ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("δ�ҵ���Ӧ�ķ�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ��ȡ�û�ѡ��ķ�������
            string selectedTranslationEngine = materialComboBox2.Text;

            // ʹ��ѡ��ķ��������Ӧ���ֵ��ȡ���Դ���
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                // ��ȡ�û�ѡ�������
                string selectedLanguage = materialComboBox3.Text;

                // ʹ���ֵ��ȡ��Ӧ�����Դ���
                if (languageMapping.TryGetValue(selectedLanguage, out string languageCodeTo))
                {
                    materialTextBox4.Text = languageCodeTo;
                }
                else
                {
                    MessageBox.Show("δ�ҵ���Ӧ�����Դ���", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("δ�ҵ���Ӧ�ķ�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLanguageComboBox(materialComboBox2.Text);
        }
    }

}
    public class ApiCredentialsManager
    {
        private const string ConfigFileName = "config.txt";

        public (string, string) ReadApiCredentials()
        {
            try
            {
                if (File.Exists(ConfigFileName))
                {
                    string[] lines = File.ReadAllLines(ConfigFileName);
                    if (lines.Length >= 2)
                    {
                        return (lines[0], lines[1]);
                    }

                }
                else
                {
                    // ����ļ������ڣ�����һ���µ��ļ�
                    File.WriteAllText(ConfigFileName, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading API credentials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (null, null);
        }

        public void SaveApiCredentials(string apiAccount, string apiKey)
        {
            try
            {
                File.WriteAllLines(ConfigFileName, new[] { apiAccount, apiKey });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving API credentials: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
public class ClipboardHelper
{
    // ����keybd_event����
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    // ���峣��
    private const int VK_CONTROL = 0x11;
    private const int VK_V = 0x56;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    // ִ��ճ������
    public static void Paste()
    {
        // ģ�ⰴ��Ctrl��
        keybd_event(VK_CONTROL, 0, 0, IntPtr.Zero);

        // ģ�ⰴ��V��
        keybd_event(VK_V, 0, 0, IntPtr.Zero);

        // ģ���ͷ�Ctrl����V��
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        keybd_event(VK_V, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
    }
}



