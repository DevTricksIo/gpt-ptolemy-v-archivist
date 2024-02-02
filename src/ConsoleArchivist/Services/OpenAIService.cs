using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text;
using ConsoleArchivist.Models.Responses;

namespace ConsoleArchivist.Services
{
    public class OpenAIService(IHttpClientFactory httpClientFactory) : IOpenAIService
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenAIAPI");

        public async Task<string?> GetTranslation(string prompt)
        {
            var url = "/v1/chat/completions";

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var jsonRequest = JsonSerializer.Serialize(Content(prompt), options);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var responseObj = JsonSerializer.Deserialize<JsonResponse>(jsonResponse);


            //return jsonResponse;

            if (responseObj != null && responseObj.Choices != null && responseObj.Choices.Length > 0)
            {
                var translation = responseObj.Choices[0].Message.Content;

                if (translation.Contains("layout") && translation.Contains("permalink") && translation.Contains("title") && translation.Contains("quote") && translation.Contains("reference"))
                {
                    return translation;
                }
            }

            return null;
        }

        private static object Content(string prompt)
        {
            return new
            {
                model = "gpt-4",
                messages = new List<object>
                {
                    new
                    {
                        role = "system",
                        content = "You are a translation assistant.\n\nI will send you some layouts in YAML and you will use them as a basis for the translation.\n\nwhere there is script you must use the ISO 15924 standard.\n\nlang type options  dead,  natural, modern, colang, colang-fictional\n\nwhere there is langtag you must use the IETF BCP 47 standard, preferably the language should use the two-letter standard, use other standards when it does not exist. for example ancient Greek is grc and modern Greek is el. When the language can be written in more than one script exclusively, you must generate another YAML for each of the scripts. example sr-Cyrl and sr-Latn\n\nJapanese is an exception because it can be written with many scripts at the same time, so it would have only one output.\n\nFor languages or variations that do not have defined ISO or IETF codes you can adopt a custom convention, such as “art-x-name”, where “art” indicates an artificial language and “x” is used for private extensions.\n\nUse the English example to translate to alther languages. \n\nOutput exemple in english\n\n---\nlayout: quote\npermalink: /en/\nlangtag: en\ntype: modern\nscript: Latn\nlangName: English\nenglishLangName: English\ntitle: Decree of Pharaoh Ptolemy V inscribed on the Rosetta Stone\nquote: Copies of this Decree shall be cut in hieroglyphs, demotic, and Greek on basalt slabs and placed in the first, second, and third-order temples alongside the statue of Ptolemy, the ever-living god.\nreference: Decrees of Ptolemy V on the Rosetta Stone, 196 B.C., British Museum.\nimageAlt: Coin with the face of Ptolemy V\nselectAriaLabel: Select a language\nbuttonRandom: Random\ndirection: ltr\n---\n\nanother output in japanese\n\n---\nlayout: quote\npermalink: /ja/\nlangtag: ja\ntype: modern\nscript: \"Hani, Hira, Kana\"\nlangName: 日本語\nenglishLangName: Japanese\ntitle: ロゼッタストーンに刻まれたプトレマイオス5世の布告\nquote: この布告のコピーは、象形文字、民衆文字、そしてギリシャ文字で玄武岩の板に刻まれ、プトレマイオス永遠の神の像とともに、第一、第二、第三の順位の寺院に配置されるでしょう。\nreference: ロゼッタストーンに刻まれたプトレマイオス5世の布告、紀元前196年、ブリティッシュ・ミュージアム。\nimageAlt: プトレマイオス五世の顔のコイン\nselectAriaLabel: 言語を選択してください\nbuttonRandom: ランダム\ndirection: vertical-rl\n---\n\nanother output in arabic\n\n---\nlayout: quote\npermalink: /ar/\nlangtag: ar\ntype: modern\nscript: Arab\nlangName: العربية\nenglishLangName: Arabic\ntitle: مرسوم الفرعون بطليموس الخامس المنقوش على حجر رشيدة\nquote:  سيتم قطع نسخ من هذا المرسوم بالهيروغليفية والديموتيك واليونانية على ألواح البازلت ووضعها في المعابده من الدرجة الأولى والثانية والثالثة بجوار تمثال بطليموس، إله الحياة الأبدية\nreference: مراسيم بطليموس الخامس على حجر رشيدة، 196 قبل الميلاد، المتحف البريطاني\nimageAlt: عملة بوجه بطليموس الخامس\nselectAriaLabel: اختر لغة\nbuttonRandom: عشوائي\ndirection: rtl\n---\n\nthe --- is parte of output keep them. every response must follow the output exemple.\n\nI will input you with a language or a language and a script and you will output with the template translated from English."
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };
        }

    }
}
