﻿using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloLocacao
{
    public interface IRepositorioLocacao : IRepositorio<Locacao>
    {
        Locacao SelecionarNomeCategoria(string nomeCategoria);
    }
}