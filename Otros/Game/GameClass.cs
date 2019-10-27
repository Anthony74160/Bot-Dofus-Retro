﻿using Bot_Dofus_1._29._1.Otros.Game.Entidades.Manejadores;
using Bot_Dofus_1._29._1.Otros.Game.Character;
using Bot_Dofus_1._29._1.Otros.Game.Server;
using Bot_Dofus_1._29._1.Otros.Mapas;
using Bot_Dofus_1._29._1.Otros.Peleas;
using System;

namespace Bot_Dofus_1._29._1.Otros.Game
{
    public class GameClass : IEliminable, IDisposable
    {
        public GameServer servidor { get; private set; }
        public Mapa mapa { get; private set; }
        public CharacterClass personaje { get; private set; }
        public Manejador manejador { get; private set; }
        public Pelea pelea{ get; private set; }
        private bool disposed = false;

        internal GameClass(Account cuenta)
        {
            servidor = new GameServer();
            mapa = new Mapa();
            personaje = new CharacterClass(cuenta);
            manejador = new Manejador(cuenta, mapa, personaje);
            pelea = new Pelea(cuenta);
        }

        #region Zona Dispose
        ~GameClass() => Dispose(false);
        public void Dispose() => Dispose(true);

        public void Clear()
        {
            mapa.Clear();
            manejador.Clear();
            pelea.Clear();
            personaje.Clear();
            servidor.Clear();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    mapa.Dispose();
                    personaje.Dispose();
                    manejador.Dispose();
                    pelea.Dispose();
                    servidor.Dispose();
                }

                servidor = null;
                mapa = null;
                personaje = null;
                manejador = null;
                pelea = null;
                disposed = true;
            }
        }
        #endregion
    }
}