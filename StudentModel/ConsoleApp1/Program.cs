using TestApp;

var test = new Test(
    new List<Unit>()
    {
        new (1, "Буркина-Фасо"),
        new (2, "Чили"),
        new (3, "Лихтенштейн"),
        new (4, "Монголия"),
    }
);


test.AddQuestion("Столица ");