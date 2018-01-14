# Picross

This is a small experiment in taking rules I use to play Picross and automating them.
I have not referred to any other solvers and I know there are smaller and quicker ways out there, but I wanted to try it myself.

Known rules  are applied to every row and every column, and the entire puzzle is iterated and attempted to be solved as long as changes are made. Once no longer successful, it stops and returns the result formatted in the console window.


# Sample Execution Before
```
┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐
│   │   │   │   │   │   │   │   │   │   │--6
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--2
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--2 1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--3 1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--1 3 3
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--6 3
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--10
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--4 5
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│   │   │   │   │   │   │   │   │   │   │--3
└───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘
  |   |   |   |   |   |   |   |   |   |
  4   1   5   5   1   1   1   10  1   1
      3           1   1   1       5   3
                  3   3   1
                          3
Press any key to start the solve...
```

# Solving a Puzzle
```
Puzzle puzzle = PuzzleBuilder.FromString(PuzzleStrings.Cherries);
PuzzleSolver solver = new PuzzleSolver();
solver.SolvePuzzle(puzzle);
Renderer.Draw(puzzle);
```

# Sample Execution After
```
┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐
│ x │ x │ x │ x │ █ │ █ │ █ │ █ │ █ │ █ │--6
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ x │ x │ x │ x │ x │ x │ x │ █ │ x │ x │--1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ x │ x │ x │ x │ x │ x │ █ │ █ │ x │ x │--2
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ x │ x │ x │ x │ █ │ █ │ x │ █ │ x │ x │--2 1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ x │ █ │ █ │ █ │ x │ x │ x │ █ │ x │ x │--3 1
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ █ │ x │ █ │ █ │ █ │ x │ █ │ █ │ █ │ x │--1 3 3
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ █ │ █ │ █ │ █ │ █ │ █ │ x │ █ │ █ │ █ │--6 3
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ █ │ █ │ █ │ █ │ █ │ █ │ █ │ █ │ █ │ █ │--10
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ █ │ █ │ █ │ █ │ x │ █ │ █ │ █ │ █ │ █ │--4 5
├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤
│ x │ x │ x │ x │ x │ x │ █ │ █ │ █ │ x │--3
└───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘
  |   |   |   |   |   |   |   |   |   |
  4   1   5   5   1   1   1   10  1   1
      3           1   1   1       5   3
                  3   3   1
                          3
Solve completed in 18.6636ms
Unknown cells left: 0
Segment passes: 11674
```
