﻿using System;
using Taikandi;

namespace Locadora_De_Veiculos.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id { get; set; }

        public EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();   
        }
    }
}
