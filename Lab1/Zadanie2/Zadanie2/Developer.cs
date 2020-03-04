using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    public class Developer
    {
        private DeveloperPosition _developerPosition;

        private int workedHours;
        private int additionalHours;
        private string imie;

        public DeveloperPosition DeveloperPosition { get => _developerPosition; set => _developerPosition = value; }
        public int WorkedHours { get => workedHours; set => workedHours = value; }
        public int AdditionalHours { get => additionalHours; set => additionalHours = value; }
        public string Imie { get => imie; set => imie = value; }

        public Developer(string i)
        {
            this.imie = i;
            this._developerPosition = new JuniorDeveloperPosition();
        }
        
        public void changeDeveloperPosition()
        {
            this._developerPosition.changeDeveloperPosition(this);
        }

    }
}
