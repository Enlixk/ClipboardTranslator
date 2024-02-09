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
            // 使用选择的翻译引擎对应的字典获取语言列表
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                materialComboBox1.Items.Clear();
                materialComboBox3.Items.Clear();
            // 将语言列表添加
                materialComboBox1.Items.AddRange(languageMapping.Keys.ToArray());
                materialComboBox3.Items.AddRange(languageMapping.Keys.ToArray());
            }
            else
            {
                //MessageBox.Show("未找到对应的翻译引擎", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //上面那句是ChatGPT生成的
            }
        }

        private Dictionary<string, Dictionary<string, string>> translationEngineMappings = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "有道翻译",
                new Dictionary<string, string>
                {
                    {"自动选择", "auto"},
                    {"简体中文", "zh-CHS"},
                    {"繁体中文", "zh-CHT"},
                    {"英语", "en"},
                    {"日语", "ja"},
                    {"俄语", "ru"},
                    {"葡萄牙语", "pt"},
                    {"意大利语", "it"},
                    {"德语", "de"},
                    {"西班牙语", "es"},
                    {"法语", "fr"},
                    {"韩语", "ko"},
                    {"粤语", "yue"},
                    {"阿拉伯语", "ar"},
                    {"印度尼西亚语", "id"},
                    {"荷兰语", "nl"},
                    {"泰语", "th"},
                    {"越南语", "vi"},
                    {"南非荷兰语", "af"},
                    {"阿姆哈拉语", "am"},
                    {"阿塞拜疆语", "az"},
                    {"白俄罗斯语", "be"},
                    {"保加利亚语", "bg"},
                    {"孟加拉语", "bn"},
                    {"波斯尼亚语", "bs"},
                    {"加泰隆语", "ca"},
                    {"宿务语", "ceb"},
                    {"科西嘉语", "co"},
                    {"捷克语", "cs"},
                    {"威尔士语", "cy"},
                    {"丹麦语", "da"},
                    {"希腊语", "el"},
                    {"世界语", "eo"},
                    {"爱沙尼亚语", "et"},
                    {"巴斯克语", "eu"},
                    {"波斯语", "fa"},
                    {"芬兰语", "fi"},
                    {"斐济语", "fj"},
                    {"弗里西语", "fy"},
                    {"爱尔兰语", "ga"},
                    {"苏格兰盖尔语", "gd"},
                    {"加利西亚语", "gl"},
                    {"古吉拉特语", "gu"},
                    {"豪萨语", "ha"},
                    {"夏威夷语", "haw"},
                    {"希伯来语", "he"},
                    {"印地语", "hi"},
                    {"克罗地亚语", "hr"},
                    {"海地克里奥尔语", "ht"},
                    {"匈牙利语", "hu"},
                    {"亚美尼亚语", "hy"},
                    {"伊博语", "ig"},
                    {"冰岛语", "is"},
                    {"爪哇语", "jw"},
                    {"格鲁吉亚语", "ka"},
                    {"哈萨克语", "kk"},
                    {"高棉语", "km"},
                    {"卡纳达语", "kn"},
                    {"库尔德语", "ku"},
                    {"柯尔克孜语", "ky"},
                    {"拉丁语", "la"},
                    {"卢森堡语", "lb"},
                    {"老挝语", "lo"},
                    {"立陶宛语", "lt"},
                    {"拉脱维亚语", "lv"},
                    {"马尔加什语", "mg"},
                    {"毛利语", "mi"},
                    {"马其顿语", "mk"},
                    {"马拉雅拉姆语", "ml"},
                    {"蒙古语", "mn"},
                    {"马拉地语", "mr"},
                    {"马来语", "ms"},
                    {"马耳他语", "mt"},
                    {"白苗语", "mww"},
                    {"缅甸语", "my"},
                    {"尼泊尔语", "ne"},
                    {"挪威语", "no"},
                    {"齐切瓦语", "ny"},
                    {"克雷塔罗奥托米语", "otq"},
                    {"旁遮普语", "pa"},
                    {"波兰语", "pl"},
                    {"普什图语", "ps"},
                    {"罗马尼亚语", "ro"},
                    {"信德语", "sd"},
                    {"僧伽罗语", "si"},
                    {"斯洛伐克语", "sk"},
                    {"斯洛文尼亚语", "sl"},
                    {"萨摩亚语", "sm"},
                    {"修纳语", "sn"},
                    {"索马里语", "so"},
                    {"阿尔巴尼亚语", "sq"},
                    {"塞尔维亚语(西里尔文)", "sr-Cyrl"},
                    {"塞尔维亚语(拉丁文)", "sr-Latn"},
                    {"塞索托语", "st"},
                    {"巽他语", "su"},
                    {"瑞典语", "sv"},
                    {"斯瓦希里语", "sw"},
                    {"泰米尔语", "ta"},
                    {"泰卢固语", "te"},
                    {"塔吉克语", "tg"},
                    {"菲律宾语", "tl"},
                    {"克林贡语", "tlh"},
                    {"汤加语", "to"},
                    {"土耳其语", "tr"},
                    {"塔希提语", "ty"},
                    {"乌克兰语", "uk"},
                    {"乌尔都语", "ur"},
                    {"乌兹别克语", "uz"},
                    {"南非科萨语", "xh"},
                    {"意第绪语", "yi"},
                    {"约鲁巴语", "yo"},
                    {"尤卡坦玛雅语", "yua"},
                    {"南非祖鲁语", "zu"},
                    // 添加更多语言...
                }
            }
            //{
                //"百度翻译",
                //new Dictionary<string, string>
                //{
                    
                    // 添加语言
                //}
            //},
            // 添加更多翻译引擎
        };

        // 导入 Windows API 函数
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
        private IntPtr handle; // 用于存储窗体句柄

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
            // 在窗体加载时读取 API 账号和密钥
            (string apiAccount, string apiKey) = credentialsManager.ReadApiCredentials();

            if (!string.IsNullOrEmpty(apiAccount) && !string.IsNullOrEmpty(apiKey))
            {
                // 在这里使用 apiAccount 和 apiKey 进行其他操作
                materialTextBox1.Text = apiAccount;
                materialTextBox2.Text = apiKey;
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // 在窗体加载时启用剪贴板监听
            LoadApiCredentials();
            FormClosed += Form1_FormClosed;  //订阅FormClosed事件                                            
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
            // 获取窗体句柄
            handle = this.Handle;
            // 启用剪贴板监听
            AddClipboardFormatListener(handle);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _globalKeyboardHook.Dispose();
            SaveApiCredentials();
            RemoveClipboardFormatListener(handle);  // 禁用剪贴板监听
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_CLIPBOARDUPDATE = 0x031D;

            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                if (materialSwitch1.Checked)               // 剪贴板内容发生变化时执行
                {
                    if (!string.Equals(Clipboard.GetText(), materialMultiLineTextBox23.Text) && Clipboard.GetText() != "") //添加对Clipboard.GetText() != ""的判断可以让用户截图时不触发
                    {
                        materialMultiLineTextBox21.Text = Clipboard.GetText(); // 读取剪贴板中的内容
                        materialMultiLineTextBox22.Text = Translate();
                        readtranslation();

                        if (materialSwitch2.Checked)
                        {
                            Clipboard.SetText(materialMultiLineTextBox23.Text);      // 最后将结果设置到剪贴板
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
        //判断是否按下了Ctrl+C组合键
        //if (e.KeyCode == Keys.C && Control.ModifierKeys == Keys.Control && materialSwitch1.Checked)
        //{
        //执行你想要的代码
        // materialMultiLineTextBox21.Text = Clipboard.GetText();
        //materialMultiLineTextBox22.Text = Translate();
        //readtranslation();
        //  Invoke(new Action(() => Clipboard.SetText(materialMultiLineTextBox23.Text)));
        //}
        //}
        //原本用检测用户按下Ctrl+C的方法，发现 读取剪切板内容 发生在 复制 这个操作之前，也就是假如我剪切板原本是1，我复制“2”，程序读取到的是1
        //所以后来改成了检测剪切板内容变化的方法

        // 您的应用ID
        //private static string APP_KEY = "";
        //您的应用密钥
        // private static string APP_SECRET = "";
        void readtranslation()
        {
            // 假设 materialMultiLineTextBox22.Text 包含你的 JSON 数据
            string jsonData = materialMultiLineTextBox22.Text;

            // 将JSON字符串解析为JObject
            JObject json = JObject.Parse(jsonData);

            // 获取translation字段的值
            JArray translationArray = json["translation"] as JArray;

            // 将数组内容连接为字符串，并设置到 materialMultiLineTextBox23 中
            if (translationArray != null)
            {
                string translationText = string.Join(Environment.NewLine, translationArray);
                // 在这里设置到 materialMultiLineTextBox23
                materialMultiLineTextBox23.Text = translationText;
            }
        }
        public string Translate()
        {
            //APP_KEY = form1.materialTextBox1.Text;
            //APP_SECRET = form1.materialTextBox2.Text;
            // 添加请求参数
            Dictionary<String, String[]> paramsMap = createRequestParams();
            // 添加鉴权相关参数
            AuthV3Util.addAuthParams(materialTextBox1.Text, materialTextBox2.Text, paramsMap);
            Dictionary<String, String[]> header = new Dictionary<string, string[]>() { { "Content-Type", new String[] { "application/x-www-form-urlencoded" } } };
            // 请求api服务
            byte[] result = HttpUtil.doPost("https://openapi.youdao.com/api", header, paramsMap, "application/json");
            // 打印返回结果
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

            // note: 将下列变量替换为需要请求的参数
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
            // 获取用户选择的翻译引擎
            string selectedTranslationEngine = materialComboBox2.Text;

            // 使用选择的翻译引擎对应的字典获取语言代号
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                // 获取用户选择的语言
                string selectedLanguage = materialComboBox1.Text;

                // 使用字典获取对应的语言代号
                if (languageMapping.TryGetValue(selectedLanguage, out string languageCodeFrom))
                {
                    materialTextBox3.Text = languageCodeFrom;
                }
                else
                {
                    //MessageBox.Show("未找到对应的语言代号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //MessageBox.Show("未找到对应的翻译引擎", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取用户选择的翻译引擎
            string selectedTranslationEngine = materialComboBox2.Text;

            // 使用选择的翻译引擎对应的字典获取语言代号
            if (translationEngineMappings.TryGetValue(selectedTranslationEngine, out Dictionary<string, string> languageMapping))
            {
                // 获取用户选择的语言
                string selectedLanguage = materialComboBox3.Text;

                // 使用字典获取对应的语言代号
                if (languageMapping.TryGetValue(selectedLanguage, out string languageCodeTo))
                {
                    materialTextBox4.Text = languageCodeTo;
                }
                else
                {
                    MessageBox.Show("未找到对应的语言代号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未找到对应的翻译引擎", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // 如果文件不存在，创建一个新的文件
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
    // 声明keybd_event函数
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    // 定义常量
    private const int VK_CONTROL = 0x11;
    private const int VK_V = 0x56;
    private const uint KEYEVENTF_KEYUP = 0x0002;

    // 执行粘贴操作
    public static void Paste()
    {
        // 模拟按下Ctrl键
        keybd_event(VK_CONTROL, 0, 0, IntPtr.Zero);

        // 模拟按下V键
        keybd_event(VK_V, 0, 0, IntPtr.Zero);

        // 模拟释放Ctrl键和V键
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        keybd_event(VK_V, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
    }
}



