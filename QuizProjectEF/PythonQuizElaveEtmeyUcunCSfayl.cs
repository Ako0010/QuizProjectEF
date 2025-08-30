

//using (var context = new QuizDBContext())
//{
//    var pythonQuiz = new Quiz
//    {
//        Category = "Python",
//        Questions = new List<Question>
//        {
//            new Question
//            {
//                Text = "Python hansı il yaradılıb?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1989", IsCorrect = true },
//                    new Answer { Text = "1995", IsCorrect = false },
//                    new Answer { Text = "2000", IsCorrect = false },
//                    new Answer { Text = "2005", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-un yaradıcı kimdir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Guido van Rossum", IsCorrect = true },
//                    new Answer { Text = "Dennis Ritchie", IsCorrect = false },
//                    new Answer { Text = "Bjarne Stroustrup", IsCorrect = false },
//                    new Answer { Text = "James Gosling", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python dilinin əsas xüsusiyyəti hansıdır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Sadə və oxunaqlı sintaksis", IsCorrect = true },
//                    new Answer { Text = "Çox mürəkkəb tip sistemi", IsCorrect = false },
//                    new Answer { Text = "Aşağı səviyyəli dil olması", IsCorrect = false },
//                    new Answer { Text = "Yalnız veb proqramlaşdırma üçün istifadə edilir", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python proqramlaşdırma dili hansı proqramlaşdırma modellərini dəstəkləyir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Obyekt yönümlü proqramlaşdırma", IsCorrect = true },
//                    new Answer { Text = "Funksional proqramlaşdırma", IsCorrect = true },
//                    new Answer { Text = "Prosedural proqramlaşdırma", IsCorrect = true },
//                    new Answer { Text = "Sıfırdan yüksək səviyyəli proqramlaşdırma", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da bir neçə funksiyanı necə təyin edə bilərik?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Bir-bir ardıcıl `def` yazmaqla", IsCorrect = true },
//                    new Answer { Text = "Bir `def` içində çoxsaylı `lambda` funksiyaları yaratmaqla", IsCorrect = false },
//                    new Answer { Text = "Sadəcə `function()` yazmaqla", IsCorrect = false },
//                    new Answer { Text = "Bir `def` ilə bir neçə funksiya yaratmaq mümkün deyil", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da siyahının uzunluğunu necə tapırıq?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "len(siyahi)", IsCorrect = true },
//                    new Answer { Text = "length(siyahi)", IsCorrect = false },
//                    new Answer { Text = "size(siyahi)", IsCorrect = false },
//                    new Answer { Text = "count(siyahi)", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da `range()` funksiyası nə işə yarayır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Sayılan bir sıra yaratmaq", IsCorrect = true },
//                    new Answer { Text = "Sıra ilə hərəkət etmək", IsCorrect = false },
//                    new Answer { Text = "Dəyişənləri sıralamaq", IsCorrect = false },
//                    new Answer { Text = "Yeni bir növ yaratmaq", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Dəyişən Nədir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Sadəcə bir obyektin adı", IsCorrect = false },
//                    new Answer { Text = "Yalnız funksiyalarda istifadə olunur", IsCorrect = false },
//                    new Answer { Text = "Adı Tipi olcusu Adressi Olan Ramda Saxlanılan Yaddaş Sahəsidir", IsCorrect = true },
//                    new Answer { Text = "Proqramın icrasını dayandırır", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da list necə təyin olunur?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "list = [1, 2, 3]", IsCorrect = true },
//                    new Answer { Text = "list = (1, 2, 3)", IsCorrect = false },
//                    new Answer { Text = "list = {1, 2, 3}", IsCorrect = false },
//                    new Answer { Text = "list = <1, 2, 3>", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da şərh yazmaq üçün hansı simvol istifadə olunur?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "#", IsCorrect = true },
//                    new Answer { Text = "//", IsCorrect = false },
//                    new Answer { Text = "/*", IsCorrect = false },
//                    new Answer { Text = "--", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da bir dəyişəni necə təyin edirik?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "x = 5", IsCorrect = true },
//                    new Answer { Text = "let x = 5", IsCorrect = false },
//                    new Answer { Text = "var x = 5", IsCorrect = false },
//                    new Answer { Text = "int x = 5", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da hansı növ verilənlər tipinə malikik?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "int, float, string, bool", IsCorrect = true },
//                    new Answer { Text = "Integer, float, string", IsCorrect = true },
//                    new Answer { Text = "Real, string, boolean", IsCorrect = false },
//                    new Answer { Text = "Set, List, Dict", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da `if`-`else` şərt blokunda hansı yazı sintaksisi düzgündür?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "if x > 5: ... else: ...", IsCorrect = true },
//                    new Answer { Text = "if x > 5: ... or else: ...", IsCorrect = false },
//                    new Answer { Text = "if x > 5; else: ...", IsCorrect = false },
//                    new Answer { Text = "if x > 5, else: ...", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da `import` komandasının funksiyası nədir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Modul daxil etmək", IsCorrect = true },
//                    new Answer { Text = "Yeni dəyişən təyin etmək", IsCorrect = false },
//                    new Answer { Text = "Dəyişəni global etmək", IsCorrect = false },
//                    new Answer { Text = "Kodun içində yeni funksiyalar yaratmaq", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da `len()` funksiyası nə işə yarayır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Bir obyektin uzunluğunu tapmaq", IsCorrect = true },
//                    new Answer { Text = "Bir funksiyanı çağırmaq", IsCorrect = false },
//                    new Answer { Text = "Bir list yaratmaq", IsCorrect = false },
//                    new Answer { Text = "Siyahı üçün yeni element təyin etmək", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da hansı növ dövr növləri mövcuddur?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "for, while, do-while", IsCorrect = true },
//                    new Answer { Text = "foreach, repeat", IsCorrect = false },
//                    new Answer { Text = "loop, repeat", IsCorrect = false },
//                    new Answer { Text = "iterate, continue", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Python-da `break` nə işə yarayır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Dövrü dayandırmaq", IsCorrect = true },
//                    new Answer { Text = "Dəyişəni sıfırlamaq", IsCorrect = false },
//                    new Answer { Text = "Yeni element yaratmaq", IsCorrect = false },
//                    new Answer { Text = "Funksiyanı dayandırmaq", IsCorrect = false },
//                }
//            },
//        }
//    };

//    context.Quizzes.Add(pythonQuiz);
//    context.SaveChanges();
//}
