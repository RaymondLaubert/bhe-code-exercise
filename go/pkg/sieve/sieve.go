package sieve

import "math"

type Sieve interface {
	NthPrime(n int64) int64
}

type Primes struct {
	primeList  []bool
	upperBound int64
}

func (p Primes) NthPrime(n int64) int64 {

	// Create the Slice to Store the Prime Numbers
	var primes = make([]int64, 0)

	// Quality of Life Variable
	apexPrime := n + 1

	if n == 0 {
		p.upperBound = 4
	} else {
		p.upperBound = int64(math.Ceil(float64(apexPrime) * math.Log(float64(apexPrime) * math.Log(float64(apexPrime)))))
	}

	// Create an Array to Mark Primes
	// False Dictates a Prime (Use False instead of True since Boolean Default Value is False in C#; This way we don't need to waste time setting them all to true)
	// True Dictates a Composite
	p.primeList = make([]bool, p.upperBound + 1)

	for pos := 2; pos * pos <= int(p.upperBound); pos++ {
		if !p.primeList[pos] {
			for itr := pos * pos; itr <= int(p.upperBound); itr += pos {
				p.primeList[itr] = true
			}
		}
	}

	for prime := 2; prime <= int(p.upperBound); prime++ {
		if !p.primeList[prime] {
			primes = append(primes, int64(prime))
		}
	}

	return primes[n]

}

func NewSieve() Sieve {
	//panic("unimplemented")

	var p Primes

	return p

}
