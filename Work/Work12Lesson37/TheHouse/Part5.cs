﻿using System.Collections.Immutable;

namespace Work12Lesson37.TheHouse
{
    public class Part5 : IPart
    {
        private ImmutableList<string> poem;
        public ImmutableList<string> Poem
        {
            get { return poem; }
            set { poem = value; }
        }
        public void AddPart(ImmutableList<string> args)
        {
            poem = ImmutableList.Create<string>(args.ToArray<string>());
            poem = poem.Add("Вот пес без хвоста,")
                .Add("Который за шиворот треплет кота,")
                .Add("Который пугает и ловит синицу,")
                .Add("Которая часто ворует пшеницу,")
                .Add("Которая в темном чулане хранится")
                .Add("В доме,")
                .Add("Который построил Джек.")
                .Add($"{Environment.NewLine}");
        }
    }
}