﻿[<AutoOpen>]
module NUnit

open NUnit.Framework

let private assrt actual expected assertion = assertion (box expected, box actual, sprintf "Expected: %+A%sActual: %+A" expected System.Environment.NewLine actual)
let (==) actual expected = assrt actual expected Assert.AreEqual
let (!=) actual expected = assrt actual expected <| fun (x, y, z) -> Assert.AreNotEqual(x, y, z)

type Test = TestAttribute

type SetUp = OneTimeSetUpAttribute

type TearDown = OneTimeTearDownAttribute

type Explicit = ExplicitAttribute

type TestCase = TestCaseAttribute

let assertThrows<'T when 'T :> exn> f message = Assert.Throws<'T>(TestDelegate f, message) |> ignore

let assertDoesNotThrow f = Assert.DoesNotThrow(TestDelegate f)