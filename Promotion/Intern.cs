using System;

namespace Promotion
{
    [Serializable]
    class Intern : Person
    {
        public string EducationLvl { get; set; }
        public bool Hire { get; set; }

        public Intern(int id, string name, string education, bool hire) : base(id, name)
        {
            EducationLvl = education;
            Hire = hire;
        }
    }
}