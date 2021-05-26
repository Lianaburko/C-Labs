namespace myClassAnimals_lab5_
{
    class Anaconda:Snake
    {
        public Anaconda()
        {
        }

        public Anaconda(string name)
             : base(name)
        {
        }

        public bool ToBeCinemaStar { get; } = true;

        public new bool Venomous { get; } = false;

        public bool DesireToSwim { get; set; }

        public string Swimming(bool swim)
        {
            if (swim == true)
            {
                return "Crawl to the river";
            }
            else
            {
                return "Warm in the sun ";
            }
        }
    }
}
