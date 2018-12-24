﻿using _03BarracksFactory.Contracts;

namespace P04_BarraksWars.Core
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Command(IRepository repository, IUnitFactory unitFactory, string[] data)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public IRepository Repository
        {
            get { return this.repository; }
            private set { this.repository = value; }
        }

        public IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            private set { this.unitFactory = value; }
        }

        public abstract string Execute();
    }
}
