# To understand why algorithm analysis is important
# To be able to use 'Big - O' to describe execution time
# To understand the 'Big - O' execution time of common operations on Python lists and dictionaries
# To understand how the implementation of Python data impacts algorithm analysis
# To understand how to benchmark simple Python programs

# sample functions
import time


def sum_of_n(n):
    start = time.time()

    result = 0
    for i in range(1, n + 1):
        result += i
    end = time.time()

    return result, end - start


def sum_of_n_2(n):
    return (n * (n + 1)) / 2


print(sum_of_n(10))
print(sum_of_n_2(10))
