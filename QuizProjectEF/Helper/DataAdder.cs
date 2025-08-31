

using QuizProject.Models;
using QuizProjectEF.DBEntity;
using QuizProjectEF.Services;

namespace QuizProjectEF.Helper;

public class DataAdder : BaseService
{
    public DataAdder(QuizDBContext context) : base(context)
    {
    }

    public void SeedDataAdding()
    {
        if (!_context.Quizzes.Any())
        {
            var allUsers = _context.Users.ToList();
            var allQuizzes = _context.Quizzes.ToList();

            var pythonQuiz = new Quiz
            {
                Category = "Python",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "Python hansı il yaradılıb?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "1989", IsCorrect = true },
                            new Answer { Text = "1995", IsCorrect = false },
                            new Answer { Text = "2000", IsCorrect = false },
                            new Answer { Text = "2005", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-un yaradıcı kimdir?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Guido van Rossum", IsCorrect = true },
                            new Answer { Text = "Dennis Ritchie", IsCorrect = false },
                            new Answer { Text = "Bjarne Stroustrup", IsCorrect = false },
                            new Answer { Text = "James Gosling", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python dilinin əsas xüsusiyyəti hansıdır?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Sadə və oxunaqlı sintaksis", IsCorrect = true },
                            new Answer { Text = "Çox mürəkkəb tip sistemi", IsCorrect = false },
                            new Answer { Text = "Aşağı səviyyəli dil olması", IsCorrect = false },
                            new Answer { Text = "Yalnız veb proqramlaşdırma üçün istifadə edilir", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python proqramlaşdırma dili hansı proqramlaşdırma modellərini dəstəkləyir? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Obyekt yönümlü proqramlaşdırma", IsCorrect = true },
                            new Answer { Text = "Funksional proqramlaşdırma", IsCorrect = true },
                            new Answer { Text = "Prosedural proqramlaşdırma", IsCorrect = true },
                            new Answer { Text = "Sıfırdan yüksək səviyyəli proqramlaşdırma", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da bir neçə funksiyanı necə təyin edə bilərik?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Bir-bir ardıcıl `def` yazmaqla", IsCorrect = true },
                            new Answer { Text = "Bir `def` içində çoxsaylı `lambda` funksiyaları yaratmaqla", IsCorrect = false },
                            new Answer { Text = "Sadəcə `function()` yazmaqla", IsCorrect = false },
                            new Answer { Text = "Bir `def` ilə bir neçə funksiya yaratmaq mümkün deyil", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da siyahının uzunluğunu necə tapırıq?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "len(siyahi)", IsCorrect = true },
                            new Answer { Text = "length(siyahi)", IsCorrect = false },
                            new Answer { Text = "size(siyahi)", IsCorrect = false },
                            new Answer { Text = "count(siyahi)", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `range()` funksiyası nə işə yarayır?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Sayılan bir sıra yaratmaq", IsCorrect = true },
                            new Answer { Text = "Sıra ilə hərəkət etmək", IsCorrect = false },
                            new Answer { Text = "Dəyişənləri sıralamaq", IsCorrect = false },
                            new Answer { Text = "Yeni bir növ yaratmaq", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Dəyişən Nədir?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Sadəcə bir obyektin adı", IsCorrect = false },
                            new Answer { Text = "Yalnız funksiyalarda istifadə olunur", IsCorrect = false },
                            new Answer { Text = "Adı Tipi olcusu Adressi Olan Ramda Saxlanılan Yaddaş Sahəsidir", IsCorrect = true },
                            new Answer { Text = "Proqramın icrasını dayandırır", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text ="Python-da siyahı (list) yaratma üsulları hansılardır? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "[]", IsCorrect = true },
                            new Answer { Text = "list()", IsCorrect = true },
                            new Answer { Text = "{}", IsCorrect = false },
                            new Answer { Text = "()", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da şərh yazmaq üçün hansı simvol istifadə olunur?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "#", IsCorrect = true },
                            new Answer { Text = "//", IsCorrect = false },
                            new Answer { Text = "/*", IsCorrect = false },
                            new Answer { Text = "--", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da bir dəyişəni necə təyin edirik?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "x = 5", IsCorrect = true },
                            new Answer { Text = "let x = 5", IsCorrect = false },
                            new Answer { Text = "var x = 5", IsCorrect = false },
                            new Answer { Text = "int x = 5", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da hansı növ verilənlər tipinə malikik? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "int, float, string, bool", IsCorrect = true },
                            new Answer { Text = "Integer, float, string", IsCorrect = true },
                            new Answer { Text = "Real, string, boolean", IsCorrect = false },
                            new Answer { Text = "Set, List, Dict", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `if`-`else` şərt blokunda hansı yazı sintaksisi düzgündür?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "if x > 5: ... else: ...", IsCorrect = true },
                            new Answer { Text = "if x > 5: ... or else: ...", IsCorrect = false },
                            new Answer { Text = "if x > 5; else: ...", IsCorrect = false },
                            new Answer { Text = "if x > 5, else: ...", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `import` komandasının funksiyası nədir? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Modul daxil etmək", IsCorrect = true },
                            new Answer { Text = "Yeni dəyişən təyin etmək", IsCorrect = false },
                            new Answer { Text = "Dəyişəni global etmək", IsCorrect = false },
                            new Answer { Text = "Kodun içində yeni funksiyalar yaratmaq", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da aşağıdakılardan hansılar funksiya təyin etməyə aiddir? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "def", IsCorrect = true },
                            new Answer { Text = "lambda", IsCorrect = true },
                            new Answer { Text = "return", IsCorrect = false },
                            new Answer { Text = "yield", IsCorrect = false },
                        }

                    },
                    new Question
                    {
                        Text = "Python-da hansı növ dövr növləri mövcuddur?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "for, while, do-while", IsCorrect = true },
                            new Answer { Text = "foreach, repeat", IsCorrect = false },
                            new Answer { Text = "loop, repeat", IsCorrect = false },
                            new Answer { Text = "iterate, continue", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `break` nə işə yarayır?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Dövrü dayandırmaq", IsCorrect = true },
                            new Answer { Text = "Dəyişəni sıfırlamaq", IsCorrect = false },
                            new Answer { Text = "Yeni element yaratmaq", IsCorrect = false },
                            new Answer { Text = "Funksiyanı dayandırmaq", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `def` nə işə yarayır?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Funksiya təyin etmək", IsCorrect = true },
                            new Answer { Text = "Dəyişən yaratmaq", IsCorrect = false },
                            new Answer { Text = "Siyahı yaratmaq", IsCorrect = false },
                            new Answer { Text = "Modul daxil etmək", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da `class` nə işə yarayır?",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "Sinif təyin etmək", IsCorrect = true },
                            new Answer { Text = "Dəyişən yaratmaq", IsCorrect = false },
                            new Answer { Text = "Funksiya yaratmaq", IsCorrect = false },
                            new Answer { Text = "Modul daxil etmək", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Text = "Python-da hansı operatorlar dövr (loop) qurmaq üçün istifadə olunur? (ÇoxSeçimli)",
                        Answers = new List<Answer>
                        {
                            new Answer { Text = "for", IsCorrect = true },
                            new Answer { Text = "while", IsCorrect = true },
                            new Answer { Text = "if", IsCorrect = false },
                            new Answer { Text = "match", IsCorrect = false },
                        }
                    }

                }
            };

            var historyQuiz = new Quiz
            {
                Category = "Tarix",
                Questions = new List<Question>
                {
            new Question
            {
                Text = "Aşağıdakılardan hansılar II Dünya Müharibəsində iştirak etmiş ölkələrdir? (ÇoxSeçimli)",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Almaniya", IsCorrect = true },
                    new Answer { Text = "SSRİ", IsCorrect = true },
                    new Answer { Text = "ABŞ", IsCorrect = true },
                    new Answer { Text = "İspaniya", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Napoleonun hakimiyyəti dövründə baş verənlər hansılardır? (ÇoxSeçimli)",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Kontinental blokada", IsCorrect = true },
                    new Answer { Text = "Waterloo döyüşü", IsCorrect = true },
                    new Answer { Text = "Versal müqaviləsi", IsCorrect = false },
                    new Answer { Text = "Parisin bombalanması 1940", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "SSRİ-nin ilk rəhbəri kim idi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Stalin", IsCorrect = false },
                    new Answer { Text = "Lenin", IsCorrect = true },
                    new Answer { Text = "Xruşşov", IsCorrect = false },
                    new Answer { Text = "Brejnev", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Osmanlı İmperiyası nə zaman süqut etdi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1918", IsCorrect = false },
                    new Answer { Text = "1923", IsCorrect = true },
                    new Answer { Text = "1945", IsCorrect = false },
                    new Answer { Text = "1939", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Hansı hadisə Fransız İnqilabı ilə əlaqəlidir?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Bastiliya qalasının ələ keçirilməsi", IsCorrect = true },
                    new Answer { Text = "Vyana konqresi", IsCorrect = false },
                    new Answer { Text = "Yalta konfransı", IsCorrect = false },
                    new Answer { Text = "Versal müqaviləsi", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Azərbaycan nə vaxt müstəqilliyini bərpa etdi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1991", IsCorrect = true },
                    new Answer { Text = "1990", IsCorrect = false },
                    new Answer { Text = "1992", IsCorrect = false },
                    new Answer { Text = "1989", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Napoleon Bonapart hansı ölkənin rəhbəri idi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Fransa", IsCorrect = true },
                    new Answer { Text = "İtaliya", IsCorrect = false },
                    new Answer { Text = "Almaniya", IsCorrect = false },
                    new Answer { Text = "İngiltərə", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "1945-ci ildə yaradılan BMT-nin mənzil qərargahı haradadır?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Nyu York", IsCorrect = true },
                    new Answer { Text = "Paris", IsCorrect = false },
                    new Answer { Text = "Cenevrə", IsCorrect = false },
                    new Answer { Text = "Londra", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Böyük Coğrafi Kəşflər dövrü hansı əsrdə başladı?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "15-ci əsr", IsCorrect = true },
                    new Answer { Text = "14-cü əsr", IsCorrect = false },
                    new Answer { Text = "16-cı əsr", IsCorrect = false },
                    new Answer { Text = "17-ci əsr", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Roma imperiyası hansı il süqut etdi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "476", IsCorrect = true },
                    new Answer { Text = "1492", IsCorrect = false },
                    new Answer { Text = "1066", IsCorrect = false },
                    new Answer { Text = "1215", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Səfəvilər dövləti dövrünə aid olan xüsusiyyətlər hansılardır? (ÇoxSeçimli)",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Şiəlik dövlət dini elan olundu", IsCorrect = true },
                    new Answer { Text = "Təbriz paytaxt idi", IsCorrect = true },
                    new Answer { Text = "Rus çarizmi ilə ittifaq quruldu", IsCorrect = false },
                    new Answer { Text = "Osmanlılarla Çaldıran döyüşü baş verdi", IsCorrect = true },
                }
            },
            new Question
            {
                Text = "Gəncə üsyanı hansı ildə baş verdi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1920", IsCorrect = true },
                    new Answer { Text = "1918", IsCorrect = false },
                    new Answer { Text = "1937", IsCorrect = false },
                    new Answer { Text = "1941", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Çingiz Xan hansı imperiyanın banisidir?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Monqol imperiyası", IsCorrect = true },
                    new Answer { Text = "Osmanlı imperiyası", IsCorrect = false },
                    new Answer { Text = "Roma imperiyası", IsCorrect = false },
                    new Answer { Text = "Fars imperiyası", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Böyük Coğrafi Kəşflərin nəticələri nələr olmuşdur? (ÇoxSeçimli)",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Yeni torpaqların kəşfi", IsCorrect = true },
                    new Answer { Text = "Sənaye inqilabı", IsCorrect = false },
                    new Answer { Text = "Koloniyaların yaradılması", IsCorrect = true },
                    new Answer { Text = "Ərəb xilafətinin süqutu", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Vətən Müharibəsi (2020) neçə gün davam etdi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "44", IsCorrect = true },
                    new Answer { Text = "30", IsCorrect = false },
                    new Answer { Text = "60", IsCorrect = false },
                    new Answer { Text = "90", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Məmməd Əmin Rəsulzadə hansı partiyanın lideri idi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Müsavat", IsCorrect = true },
                    new Answer { Text = "Bolşevik", IsCorrect = false },
                    new Answer { Text = "Taşnak", IsCorrect = false },
                    new Answer { Text = "Kadet", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Qızıl Orda dövləti harada yaranmışdı?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "Orta Asiya", IsCorrect = true },
                    new Answer { Text = "Avropa", IsCorrect = false },
                    new Answer { Text = "Hindistan", IsCorrect = false },
                    new Answer { Text = "Çin", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "İngiltərədə Magna Carta hansı ildə qəbul edilib?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1215", IsCorrect = true },
                    new Answer { Text = "1315", IsCorrect = false },
                    new Answer { Text = "1115", IsCorrect = false },
                    new Answer { Text = "1415", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Hitler Almaniyada hakimiyyətə nə vaxt gəldi?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1933", IsCorrect = true },
                    new Answer { Text = "1929", IsCorrect = false },
                    new Answer { Text = "1939", IsCorrect = false },
                    new Answer { Text = "1945", IsCorrect = false },
                }
            },
            new Question
            {
                Text = "Səfəvilər dövləti hansı il yaranmışdır?",
                Answers = new List<Answer>
                {
                    new Answer { Text = "1501", IsCorrect = true },
                    new Answer { Text = "1401", IsCorrect = false },
                    new Answer { Text = "1601", IsCorrect = false },
                    new Answer { Text = "1701", IsCorrect = false },
                }
            },
        }
            };
            _context.Quizzes.AddRange(pythonQuiz,historyQuiz);
            _context.SaveChanges();
        }
    }
}



               
