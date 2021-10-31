module Honeycomb.Core.Parser

open System
open System.Buffers.Binary

type ParseError = { Message: string }

type Parser<'a> = ArraySegment<byte> -> Result<'a * ArraySegment<byte>, ParseError>


let intBytes : Parser<ArraySegment<byte>> = 
    fun segment ->
        try
            Ok(segment.Slice(0, 4), segment.Slice(4))
        with
            | _ -> Error({ Message = "unable to parse int" })


let doubleBytes : Parser<ArraySegment<byte>> =
    fun segment ->
        try
            Ok(segment.Slice(0, 8), segment.Slice(8))
        with
            | _ -> Error({ Message = "unable to parse double" })



let bind (f: 'a -> Parser<'b>) (parser: Parser<'a>) : Parser<'b> =
    fun (segment) ->
        segment
        |> parser
        |> Result.bind (fun (item, rest) -> 
            (f item) rest)



let map (f: 'a -> 'b) (parser : Parser<'a>) : Parser<'b> =
    fun arr ->
        arr
        |> parser
        |> Result.map (fun (item, rest) ->
            (f item, rest))


let zero : Parser<'a> = fun (arr : ArraySegment<byte>) -> Error({ Message = "zero here?" })


let succeed item : Parser<'a> = fun (arr : ArraySegment<byte>) -> Ok(item, arr)


let apply (p: Parser<'a -> 'b>) (q: Parser<'a>) : Parser<'b> =
    p |> bind (fun f -> q |> map f)


type ParserBuilder() =
    member this.Bind(parser, f) = bind f parser
    member this.Return(item) = succeed item
    member this.Zero() = zero

let parse = ParserBuilder()


let parseLittleDouble (bytes : ArraySegment<byte>) : double =
    BinaryPrimitives.ReadDoubleLittleEndian (ReadOnlySpan<byte>.op_Implicit(bytes))


let parseLittleInt (bytes : ArraySegment<byte>) : int =
    BinaryPrimitives.ReadInt32LittleEndian (ReadOnlySpan<byte>.op_Implicit(bytes))


let parseBigInt (bytes : ArraySegment<byte>) : int =
    BinaryPrimitives.ReadInt32BigEndian (ReadOnlySpan<byte>.op_Implicit(bytes))
    

let littleDouble : Parser<double> =
    doubleBytes |> map parseLittleDouble


let bigInt : Parser<int> =
    intBytes |> map parseBigInt


let littleInt : Parser<int> =
    intBytes |> map parseLittleInt



let take count (parser: Parser<'a>) : Parser<list<'a>> = 
    seq { 0 .. (count - 1) }
    |> Seq.fold (fun result _ -> parse {
        let! list = result
        let! next = parser
        return next::list }) (succeed [])
