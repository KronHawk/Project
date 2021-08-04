using System;
using System.Collections.Generic;
using System.Text;

namespace series
{
    class serierepository : irepository<Services>
    {
        private List<Services> listaserie = new List<Services>();
        public void atualiza(int id, Services entidade)
        {
            listaserie[id] = entidade;
        }

        public void exclui(int id)
        {
            listaserie[id].Exclui();
        }

        public void insere(Services entidade)
        {
            listaserie.Add(entidade);
        }

        public List<Services> Lista()
        {
            return listaserie;
        }

        public int proximoId()
        {
            return listaserie.Count;
        }

        public Services RetornarporId(int id)
        {
            return listaserie[id];
        }
    }
}
