using System;

namespace Arielle
{
    public class CompteurTempsRegle
    {
        public float TempsRestant { 
            get;
            private set;
        }

        public bool EstTermine => TempsRestant <= 0f;

        public CompteurTempsRegle(float duree)
        {
            TempsRestant = duree;
        }

        public void Avancer(float secondes)
        {
            TempsRestant = Math.Max(0f, TempsRestant - secondes);
        }

    }
}