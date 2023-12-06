﻿using System.Collections.Immutable;

namespace Work12Lesson37.TheHouse
{
    public class Part2 : IPart
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
            poem = poem.Add("А это пшеница,")
                .Add("Которая в темном чулане хранится")
                .Add("В доме,")
                .Add("Который построил Джек.")
                .Add($"{Environment.NewLine}");  
        }
    }
}
