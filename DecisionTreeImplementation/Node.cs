using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    internal class Node
    {
        private readonly DecisionTree tree;

        public ICollection<IExampleRow> Population { get; set; }

        public Split OutgoingSplit { get; set; }

        public Node(DecisionTree tree)
        {
            this.OutgoingSplit = new Split();
            this.tree = tree;
        }

        public Node(DecisionTree tree, ICollection<IExampleRow> population)
            : this(tree)
        {
            this.Population = population.OrderBy(x => x.Class).ToList();
        }

        public void TrySplit()
        {
            // Es muss versucht werden nach jedem Feature zu splitten
            // Es muss an jeder stelle jedes Wertes von jedem Feature versucht werden
            // Der beste Information Gain wird zwischen gepeichert (und das Feature und der Split Wert)

            // Für jedes Feature
            foreach (var possibleFeature in this.tree.ExisitingFeatures)
            {
                // Für jeden Split Punkt
                foreach (var citizen in this.Population)
                    //.OrderBy(x => x.Items.Where(y => y.RelatedFeature.Name == possibleFeature)))
                {
                    // Splitwert holen
                    var value = citizen.Items.Where(x => x.RelatedFeature.Name == possibleFeature).Single().Value;

                    // alle kleiner und alle größer auftrennen
                    List<IExampleRow> smallerEqual = new List<IExampleRow>();
                    List<IExampleRow> greater = new List<IExampleRow>();

                    // den gesplitteten in den smaller Equal
                    smallerEqual.Add(citizen);

                    foreach (var splitCandidate in this.Population.Where(x => x != citizen))
                    {
                        // prüfen wenn Wert des Features kleiner dem Split Value dann nach links sonst nach rechts
                        if (splitCandidate.Items.Where(x => x.RelatedFeature.Name == possibleFeature).Single()?.Value <= value)
                            smallerEqual.Add(splitCandidate);
                        else
                            greater.Add(splitCandidate);
                    }

                    // Entropie und Information Gain berechnen für beide Teilknoten
                    // Wenn besser als bisherige -> speichern
                }
            }
        }

        public double GetEntropie()
        {
            double entropie = 0;

            foreach (string className in this.tree.ExistingClasses)
            {
                double classCount = this.Population.Count(x => x.Class == className);
                double populationCount = this.Population.Count;

                entropie += -1 * ((classCount / populationCount) * Math.Log((classCount / populationCount), 2));
            }

            return entropie;
        }
    }
}
