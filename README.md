这是一个用C#写的小程序，源于2024年1月某天英语自习课的突发奇想。  
它可以自动翻译你剪切板中的内容，还可以进一步将你剪切板中的内容替换为翻译后的内容，还可以自动粘贴。  
写这个程序写着玩的，我只是一个高中生，本身不是专业的，也只是了解过，基本没学过编程相关的知识。  
代码99%以上是ChatGPT、Copilot写的或者百度上抄的，我自己整合的跟sh*t一样，大佬勿喷。  

  注意，目前只支持有道翻译引擎，需在有道智云后台自行申请自然语言翻译服务-文本翻译，并在软件中设置一栏填写API Key和API Secret  
  有道智云后台 https://ai.youdao.com/console  
(我抄的有道API文档C#的示例代码，里面是API Key和API Secret，总之当作是你后台的应用ID和应用密钥就是了)  
之后再看看能不能本地翻译和接入更多在线翻译API

![preview](https://github.com/Enlixk/ClipboardTranslator/assets/58211772/95ad4be8-707c-4577-9d00-1c86a0d3dd33)  
  
选择有道翻译引擎时，如果原语言和目标语言均选择“自动选择”，那么自动中译英，外文译中。  
自动粘贴采用模拟键盘按下Ctrl+V。  
我目前高三，快高考了，以后有时间再添加对其他翻译平台的调用。  
或者有人感兴趣的话可以重写一个更好的或者fork我这一个去改(但我写的跟sh*t一样)  

