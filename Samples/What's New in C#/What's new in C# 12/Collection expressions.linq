<Query Kind="Statements" />

// Rather than initializing an array as follows:
char[] vowels1 = {'a', 'e', 'i', 'o', 'u'};

// you can now use square brackets (a "collection expression"):
char[] vowels2 = ['a', 'e', 'i', 'o', 'u'];

// Collection expressions have two major advantages. First, the same syntax also works
// with other collection types, such as lists and sets (and even the low-level span types):
List<char> list = ['a', 'e', 'i', 'o', 'u'];
HashSet<char> set = ['a', 'e', 'i', 'o', 'u'];
ReadOnlySpan<char> span = ['a', 'e', 'i', 'o', 'u'];

list.Dump ("list");
set.Dump ("set");
span.Dump ("span");

// Second, they are target-typed, which means that you can omit the type in other
// scenarios where the compiler can infer it, such as when calling methods:
Foo (['a', 'e', 'i', 'o', 'u']);

void Foo (char[] letters) => letters.Dump ("letters");

// A collection expression can include other collections if prefixed by the .. (spread) operator:
int[] odd = [1, 3, 5];
int[] even = [2, 4, 6];
int[] both = [..odd, ..even, 7, 8];
both.Dump ("Both");



