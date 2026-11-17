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

        public void Ajouter()
        {
            Nombre++;
        }

        public void Retirer()
        {
            if (Nombre > 0)
                Nombre--;
        }
    }
}