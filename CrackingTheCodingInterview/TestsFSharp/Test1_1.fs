module Test1_1

open CodeFSharp.Question1_1
open NUnit.Framework
open FsUnit

[<Test>]
let ``No Duplicate returns true`` () =
    // Arrange
    let expected = true
    let input = "abc"

    // Act
    let actual = AreAllCharactersUnique input

    // Assert
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Duplicates returns false`` () =
    // Arrange
    let expected = false
    let input = "aba"

    // Act
    let actual = AreAllCharactersUnique input

    // Assert
    Assert.AreEqual (expected, actual)

[<Test>]
let ``Casing difference returns true`` () =
    // Arrange
    let expected = true
    let input = "Aa"

    // Act
    let actual = AreAllCharactersUnique input

    // Assert
    Assert.AreEqual (expected, actual)