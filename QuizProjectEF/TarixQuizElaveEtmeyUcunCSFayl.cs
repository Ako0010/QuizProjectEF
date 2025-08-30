



//using (var context = new QuizDBContext())
//{
//    var historyQuiz = new Quiz
//    {
//        Category = "Tarix",
//        Questions = new List<Question>
//        {
//            new Question
//            {
//                Text = "Azərbaycan Xalq Cümhuriyyəti hansı ildə elan edildi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1918", IsCorrect = true },
//                    new Answer { Text = "1920", IsCorrect = false },
//                    new Answer { Text = "1945", IsCorrect = false },
//                    new Answer { Text = "1991", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "II Dünya Müharibəsi nə vaxt başladı?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1939", IsCorrect = true },
//                    new Answer { Text = "1941", IsCorrect = false },
//                    new Answer { Text = "1935", IsCorrect = false },
//                    new Answer { Text = "1943", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "SSRİ-nin ilk rəhbəri kim idi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Stalin", IsCorrect = false },
//                    new Answer { Text = "Lenin", IsCorrect = true },
//                    new Answer { Text = "Xruşşov", IsCorrect = false },
//                    new Answer { Text = "Brejnev", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Osmanlı İmperiyası nə zaman süqut etdi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1918", IsCorrect = false },
//                    new Answer { Text = "1923", IsCorrect = true },
//                    new Answer { Text = "1945", IsCorrect = false },
//                    new Answer { Text = "1939", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Hansı hadisə Fransız İnqilabı ilə əlaqəlidir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Bastiliya qalasının ələ keçirilməsi", IsCorrect = true },
//                    new Answer { Text = "Vyana konqresi", IsCorrect = false },
//                    new Answer { Text = "Yalta konfransı", IsCorrect = false },
//                    new Answer { Text = "Versal müqaviləsi", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Azərbaycan nə vaxt müstəqilliyini bərpa etdi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1991", IsCorrect = true },
//                    new Answer { Text = "1990", IsCorrect = false },
//                    new Answer { Text = "1992", IsCorrect = false },
//                    new Answer { Text = "1989", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Napoleon Bonapart hansı ölkənin rəhbəri idi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Fransa", IsCorrect = true },
//                    new Answer { Text = "İtaliya", IsCorrect = false },
//                    new Answer { Text = "Almaniya", IsCorrect = false },
//                    new Answer { Text = "İngiltərə", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "1945-ci ildə yaradılan BMT-nin mənzil qərargahı haradadır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Nyu York", IsCorrect = true },
//                    new Answer { Text = "Paris", IsCorrect = false },
//                    new Answer { Text = "Cenevrə", IsCorrect = false },
//                    new Answer { Text = "Londra", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Böyük Coğrafi Kəşflər dövrü hansı əsrdə başladı?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "15-ci əsr", IsCorrect = true },
//                    new Answer { Text = "14-cü əsr", IsCorrect = false },
//                    new Answer { Text = "16-cı əsr", IsCorrect = false },
//                    new Answer { Text = "17-ci əsr", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Roma imperiyası hansı il süqut etdi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "476", IsCorrect = true },
//                    new Answer { Text = "1492", IsCorrect = false },
//                    new Answer { Text = "1066", IsCorrect = false },
//                    new Answer { Text = "1215", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Berlin divarı nə vaxt dağıldı?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1989", IsCorrect = true },
//                    new Answer { Text = "1991", IsCorrect = false },
//                    new Answer { Text = "1985", IsCorrect = false },
//                    new Answer { Text = "1995", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Gəncə üsyanı hansı ildə baş verdi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1920", IsCorrect = true },
//                    new Answer { Text = "1918", IsCorrect = false },
//                    new Answer { Text = "1937", IsCorrect = false },
//                    new Answer { Text = "1941", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Çingiz Xan hansı imperiyanın banisidir?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Monqol imperiyası", IsCorrect = true },
//                    new Answer { Text = "Osmanlı imperiyası", IsCorrect = false },
//                    new Answer { Text = "Roma imperiyası", IsCorrect = false },
//                    new Answer { Text = "Fars imperiyası", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Amerika Birləşmiş Ştatları hansı ildə müstəqil oldu?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1776", IsCorrect = true },
//                    new Answer { Text = "1789", IsCorrect = false },
//                    new Answer { Text = "1804", IsCorrect = false },
//                    new Answer { Text = "1750", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Vətən Müharibəsi (2020) neçə gün davam etdi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "44", IsCorrect = true },
//                    new Answer { Text = "30", IsCorrect = false },
//                    new Answer { Text = "60", IsCorrect = false },
//                    new Answer { Text = "90", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Məmməd Əmin Rəsulzadə hansı partiyanın lideri idi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Müsavat", IsCorrect = true },
//                    new Answer { Text = "Bolşevik", IsCorrect = false },
//                    new Answer { Text = "Taşnak", IsCorrect = false },
//                    new Answer { Text = "Kadet", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Qızıl Orda dövləti harada yaranmışdı?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "Orta Asiya", IsCorrect = true },
//                    new Answer { Text = "Avropa", IsCorrect = false },
//                    new Answer { Text = "Hindistan", IsCorrect = false },
//                    new Answer { Text = "Çin", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "İngiltərədə Magna Carta hansı ildə qəbul edilib?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1215", IsCorrect = true },
//                    new Answer { Text = "1315", IsCorrect = false },
//                    new Answer { Text = "1115", IsCorrect = false },
//                    new Answer { Text = "1415", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Hitler Almaniyada hakimiyyətə nə vaxt gəldi?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1933", IsCorrect = true },
//                    new Answer { Text = "1929", IsCorrect = false },
//                    new Answer { Text = "1939", IsCorrect = false },
//                    new Answer { Text = "1945", IsCorrect = false },
//                }
//            },
//            new Question
//            {
//                Text = "Səfəvilər dövləti hansı il yaranmışdır?",
//                Answers = new List<Answer>
//                {
//                    new Answer { Text = "1501", IsCorrect = true },
//                    new Answer { Text = "1401", IsCorrect = false },
//                    new Answer { Text = "1601", IsCorrect = false },
//                    new Answer { Text = "1701", IsCorrect = false },
//                }
//            },
//        }
//    };

//    context.Quizzes.Add(historyQuiz);
//    context.SaveChanges();
//}