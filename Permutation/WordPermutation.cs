using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutacao
{
    public class WordPermutation
    {
        private readonly List<string> _characters;
        private readonly List<string> _possibleResults;

        public WordPermutation()
        {
            _characters = new List<string>();
            _possibleResults = new List<string>();
        }

        public void Find(string word)
        {
            InitializeCharacters(word);
            SearchLowerLevels();
            SearchHigherLevels(word.Length);
            //_possibleResults.Distinct().ToList().ForEach(Console.WriteLine);
            Console.WriteLine($"Encontradas {_possibleResults.Count} possibilidades.");
        }

        private void InitializeCharacters(string word)
        {
            foreach (var character in word)
            {
                _characters.Add(character.ToString());
                _possibleResults.Add(character.ToString());
            }
        }

        private void SearchLowerLevels()
        {
            _characters.ForEach(character =>
            {
                var listWithoutRoot = _characters.ToList();
                FindCombinations(character, listWithoutRoot).ForEach(combination =>
                {
                    _possibleResults.Add($"{combination}");
                });
                FindPermutations(character, listWithoutRoot).ForEach(permutation =>
                {
                    _possibleResults.Add($"{permutation}");
                });
            });
        }

        private void SearchHigherLevels(int wordLength)
        {
            for (var wordSize = 1; wordSize < wordLength - 1; wordSize++)
            {
                var root = _characters.GetRange(0, wordSize);
                var remainingCharacters = _characters.ToList();
                var rootWord = "";
                root.ForEach(subWord =>
                {
                    rootWord += subWord;
                    remainingCharacters.Remove(subWord);
                });
                remainingCharacters.ForEach(character =>
                {
                    var listWithoutRoot = remainingCharacters.ToList();
                    FindCombinations(character, listWithoutRoot).ForEach(combination =>
                    {
                        _possibleResults.Add($"{rootWord}{combination}");
                    });
                    FindPermutations(character, listWithoutRoot).ForEach(permutation =>
                    {
                        _possibleResults.Add($"{rootWord}{permutation}");
                    });
                });
            }
        }

        private static List<string> FindCombinations(string root, List<string> possibleCharacters)
        {
            var possibleCombinations = new List<string>();
            possibleCharacters.Remove(root);
            possibleCharacters.ForEach(character => { possibleCombinations.Add($"{root}{character}"); });
            return possibleCombinations;
        }

        private static List<string> FindPermutations(string root, List<string> possibleCharacters)
        {
            var possiblePermutations = new List<string>();
            possibleCharacters.Remove(root);
            SeparateUnitPermutations(possibleCharacters).ForEach(unitPermutation =>
            {
                possiblePermutations.Add($"{root}{unitPermutation}");
            });
            return possiblePermutations;
        }

        private static List<string> SeparateUnitPermutations(List<string> possibleCharacters)
        {
            var unitPermutations = new List<string>();
            possibleCharacters.ForEach(character =>
            {
                var otherCharacters = possibleCharacters.ToList();
                otherCharacters.Remove(character);
                FindCombinations(character, otherCharacters).ForEach(combination =>
                {
                    unitPermutations.Add(combination);
                });
            });
            return unitPermutations;
        }
    }
}