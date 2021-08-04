using System;
using System.Collections.Generic;
using System.Text;

namespace series
{
    interface irepository<T>
    {
        List<T> Lista();
        T RetornarporId(int id);
        void insere(T entidade);
        void exclui(int id);
        void atualiza(int id, T entidade);
        int proximoId();

    }
}
