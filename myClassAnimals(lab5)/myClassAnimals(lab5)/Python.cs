namespace myClassAnimals_lab5_
{
    class Python:Snake
    {
        public Python()
        {
        }

        public Python(string name)
             :base(name)
        {
        }

        private bool progLanguage;

        public bool BeTheSymbolOfProgrammingLanguage
        {
            set
            {
                progLanguage = true;
            }
            get
            {
                return progLanguage;
            }
        }

        public int AmountOfSpecies { get; } = 41;

        public int AmountOfGenuses { get; } = 9;

        public new bool Venomous { get; } = false;

        public bool DesireToHuntForAHuman { get; set; }

        public string Color { get; set; }
    }
}
