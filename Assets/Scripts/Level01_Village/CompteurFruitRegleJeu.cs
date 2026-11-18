using UnityEngine;

namespace Arielle
{
    public class CompteurFruitRegleJeu
    {
        public int Nombre
        {
            get;
            private set;
        } = 0;

        public int Maximum
        {
            get;
            private set;
        }

        public CompteurFruitRegleJeu(int maximum)
        {
            Maximum = maximum;
        }

        public void Ajouter()
        {
            if (Nombre < Maximum)
                Nombre++;
        }

        public void Retirer()
        {
            if (Nombre > 0)
                Nombre--;
        }
    }
}