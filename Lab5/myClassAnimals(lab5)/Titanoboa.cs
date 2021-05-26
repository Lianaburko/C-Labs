namespace myClassAnimals_lab5_
{
    sealed class Titanoboa:Snake
    {
        public Titanoboa()
        {
        }

        public Titanoboa(string name)
             : base(name)
        {
        }

        private string genus;

        public new string SetGenus
        {
            set
            {
                genus = "Titanoboa";
            }
            get
            {
                return genus;
            }
        }
        
        public string TimeOfExisting
        {
            get
            {
                return "Snake existed around 58 to 60 million years ago";
            } 
        }

        public new string SetOfLivingPlace
        {
            get
            {
                return "Living place was La Guajira in northeastern Colombia";
            }
        }

        public string MusiamsToFindSkeleton { get; set; }
    }
}
