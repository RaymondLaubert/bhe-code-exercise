namespace Sieve;

public interface ISieve
{
    long NthPrime(long n);
}

public class SieveImplementation : ISieve
{
    public long NthPrime(long n)
    {
        // Creating a List to Store Primes 
        var primes = new List<long>();

        // Determine the Upper Bound for the N'th Prime (+1 Due to 0-Index)
        var upperBound = n != 0 ? Math.Ceiling((n + 1) * Math.Log((n + 1) * Math.Log(n + 1))) : 4;

        // Create an Array to Mark Primes
        // False Dictates a Prime (Use False instead of True since Boolean Default Value is False in C#; This way we don't need to waste time setting them all to true)
        // True Dictates a Composite
        bool[] searchArea = new bool[(int)upperBound + 1];

        // Iterate through the Search Area (where 'pos' represents the Current Position)
        // Stop when the 'Potential' Primes Squared would exceed the Upper Bound
        for (long pos = 2; Math.Pow(pos, 2) <= upperBound; pos++)
        {
            if (!searchArea[pos])
            {
                // Iterate through All the Multiples Starting from the Current Prime^2
                for (long itr = pos * pos; itr <= upperBound; itr += pos)
                {
                    searchArea[itr] = true;
                }
            }
        }

        // Add the Primes to the List
        for (int prime = 2; prime <= upperBound; prime++)
        {
            if (!searchArea[prime])
            {
                primes.Add(prime);
            }
        }

        return primes[(int)n];

    }
}