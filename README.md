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
