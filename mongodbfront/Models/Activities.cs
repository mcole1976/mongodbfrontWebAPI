namespace mongodbfront.Models
{
    public class Activities
    {
        private bool _walk;
        private bool _cycle;
      private bool _calories;
        private bool _workout;
      private bool _read;
        private bool _code;

        public bool Walk { get => _walk; set => _walk = value; }
        public bool Cycle { get => _cycle; set => _cycle = value; }
        public bool Calories { get => _calories; set => _calories = value; }
        public bool Workout { get => _workout; set => _workout = value; }
        public bool Read { get => _read; set => _read = value; }
        public bool Code { get => _code; set => _code = value; }
    }
}
