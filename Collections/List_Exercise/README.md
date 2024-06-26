# List Manipulation Methods and Classes in C#

## Methods

### Merge Two Lists
- **Description**: Merges two lists by inserting elements from the second list into the first list at alternate positions.
- **Input**: Two `List<T>`
- **Output**: New `List<T>` with elements merged at alternate positions.

### Remove Duplicates
- **Description**: Removes duplicate elements from a list.
- **Input**: `List<T>`
- **Output**: New `List<T>` without duplicates.

### Find Common Elements
- **Description**: Returns a new list containing only the elements that are common to both input lists.
- **Input**: Two `List<T>`
- **Output**: New `List<T>` of common elements.

### Partition a List
- **Description**: Splits the list into two lists based on a predicate function.
- **Input**: `List<T>` and a predicate (`Func<T, bool>`)
- **Output**: Two new `List<T>`, one for elements where predicate is true, and another where predicate is false.

### Rotate a List
- **Description**: Rotates the list such that the first 'n' elements are moved to the end of the list.
- **Input**: `List<T>` and an integer `n`
- **Output**: New `List<T>` that is rotated.

### Find the kth Largest Element
- **Description**: Finds the kth largest element in the list.
- **Input**: `List<T>` and an integer `k`
- **Output**: Element of type `T`.

### Find Longest Sequence of Consecutive Elements
- **Description**: Identifies the longest sequence of consecutive elements in a list.
- **Input**: `List<T>`
- **Output**: New `List<T>` representing the longest consecutive sequence.

## Usage

To use these methods and classes, ensure your project references the necessary generics library and that you adapt types according to your specific use case.
