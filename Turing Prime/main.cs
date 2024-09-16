using System;
using System.Collections.Generic ;

/*
    The CTuringTest class implements algorithm for finding smallest sum
    of prime factors of a positive number recursively.
    For example number 9 has factors 3 and 3;
        their summary is 6=3+3;
        prime factors for 6 are 2 and 3: 2*3=6;
        their summary is 5, which does not have factors because it is a prime number.
    So the expected result for input 9 is 5.

    Algorithm:
        Step 1: build list of prime factors for a given number;
        Step 2: replace the given number with the summary of its prime factors;
        repeat Step 1 and Step 2 until length of a list with prime factors is 1.
*/  
class CTuringTest {
    private int m_iNum=0 ;
    /*  fnCalcPrimeNumbers is a helper function that builds a list of prime numbers
        between 2 and the one we should examine, including it.
        The result of fnCalcPrimeNumbers function is used to produce
        list of prime factors for a given number and summary of its prime factors.
    */
    private List<int>? fnCalcPrimeNumbers () {
        //  aiRes a resulting list that contains list of prie numbers
        List<int>? aiRes =null;
        //  Check every number between 2 and the given one.
        //  If its divisible by any number other then itself
        //  then its not primary and shouldn't be included
        //  into the resulting list.
        for (int iNum=2; iNum<=m_iNum; ++iNum) {
            int iAnum=2;
            for (iAnum=2; iAnum<=iNum && 0!=iNum%iAnum; ++iAnum) ;
            //  if iNum is divisible only by itself
            //  then add it to the resulting list
            if (iAnum==iNum && 0==iNum%iAnum) {
                if (null==aiRes) {
                    aiRes=new List<int>() ;
                }
                aiRes.Add(iNum) ;
            }
        }
        return aiRes ;
    }
    /*
        The fnProcess function repeatedly produces lists of prime numbers for a given number,
        calculates summary of elements from that list until the list contains only one number
        indicating that it can not be divided any more and therefore represents the 
        algorithm's answer.
    */
    public int fnProcess() {
        //  This is the algorithm's answer: result(Integer)
        int iRes=0 ;
        //  aiPrimes is a list of prime numbers between 2 and the one I examine
        List<int> ? aiPrimes=fnCalcPrimeNumbers() ;
        if (null != aiPrimes && 0<aiPrimes.Count) {
            //  iAnum is the current summary of prime factors
            int iAnum=m_iNum ;
            //  aiFactors is the list of prime factors
            List<int>?aiFactors=null;
            do {
                aiFactors=null;
                int iPrimeIndex=0;
                //  Repeat dividing current summary by the prime numbers from the aiPrimes list
                //  while the quotient is greater then the smallest prime number 2
                for (iPrimeIndex=0; iPrimeIndex<aiPrimes.Count && iAnum>=aiPrimes[iPrimeIndex]; ++iPrimeIndex) {
                    //  If division by a prime number is exact then
                    if (0==iAnum%aiPrimes[iPrimeIndex]) {
                        if (null==aiFactors) {
                            aiFactors=new List<int>() ;
                        }
                        //  Append prime divisor to the list of factors
                        aiFactors.Add(aiPrimes[iPrimeIndex]) ;
                        //  Calculate the quotient
                        iAnum/=aiPrimes[iPrimeIndex] ;
                        //  Reset index of the array with prime nunbers to
                        //  continue finding other prime factors
                        iPrimeIndex=-1;
                    }
                }
                //  Once all prime factors of the current iAnum are
                //  accumulated in the aiFactors list
                if (null!=aiFactors && 1<aiFactors.Count) {
                    //  Replace iAnum with the summary of its factors
                    //  to repeat the process
                    iAnum=aiFactors.Sum() ;
                }
                //  Continue fatorization until there are more then one factor
            } while (null!=aiFactors && 1<aiFactors.Count) ;
            //  Result is the summary of factors;
            //  although there should be only one factor;
            if (null != aiFactors) {
                iRes=aiFactors.Sum() ;
            }
        }
        return iRes ;
    }
    /*
        Cunstructore of the CTuringTest class simply stores the number
        to be examined in its member variable.
    */
    public CTuringTest (int IN_iNum) {
        m_iNum=IN_iNum ;
    }
    //  The main function of the console application
    //  prompts user for a number to examine and tries to convert
    //  user's input into integer.
    static int Main(string[] args) {
        int iRes=0, iNum=0 ;
        if (0>=args.Length || !int.TryParse(args[0], out iNum) || 2>=iNum) {
            Console.WriteLine("Enter a positive integer greater then 2");
            iRes = -1 ;
        } else {
            CTuringTest oWork = new CTuringTest(iNum) ;
            int iSmallestSum=oWork.fnProcess() ;
            Console.WriteLine(string.Format("Smallest sum={0}", iSmallestSum));
        }
        return iRes ;
    }
}
