namespace CodeFSharp

// 1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters.
// What if you cannot use additional data structures?
module Question1_1 =
    let private CountUniqueCharacters string =
        string
            |> Seq.distinct
            |> Seq.length

    // Space: O(N)
    // Time: O(N)
    let AreAllCharactersUnique string =
        Seq.length string = CountUniqueCharacters string   