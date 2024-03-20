-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 20, 2024 at 10:34 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project`
--

-- --------------------------------------------------------

--
-- Table structure for table `question`
--

CREATE TABLE `question` (
  `QuestionID` int(11) NOT NULL,
  `Language` varchar(50) NOT NULL,
  `QuestionText` text NOT NULL,
  `Points` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `question`
--

INSERT INTO `question` (`QuestionID`, `Language`, `QuestionText`, `Points`) VALUES
(1, 'C++', 'Write a C++ function to calculate the factorial of a given number using recursion.', 10),
(2, 'C++', 'Write a C++ function to reverse a given string without using any library functions.', 10),
(3, 'C++', 'Write a C++ function to check if a given string is a palindrome or not.', 10),
(4, 'C++', 'Write a C++ function to print the Fibonacci series up to a given number of terms.', 10),
(5, 'C++', 'Write a C++ program to print all prime numbers between 1 and N.', 10),
(6, 'C++', 'Write a C++ function to perform a binary search on a sorted array.', 10),
(7, 'C++', 'Write a C++ program to sort an array of integers using the bubble sort algorithm.', 10),
(8, 'C++', 'Implement basic operations (insertion, deletion, traversal) on a singly linked list in C++.', 10),
(9, 'C++', 'Implement a stack data structure in C++ with push, pop, and top operations.', 10),
(10, 'C++', 'Implement a queue data structure in C++ with enqueue, dequeue, and front operations.', 10),
(11, 'C++', 'Provide an overview of the C++ programming language, including its features and benefits.', 5),
(12, 'C++', 'Discuss the key concepts of OOP, such as encapsulation, inheritance, and polymorphism, and how they are implemented in C++.', 5),
(13, 'C++', 'Define classes and objects in C++ and explain their relationship with each other.', 5),
(14, 'C++', 'Explain the differences between stack and heap memory allocation in C++.', 5),
(15, 'C++', 'Describe pointers in C++ and discuss their usage and advantages.', 5),
(16, 'C++', 'Explain virtual functions and polymorphism in C++, including their role in achieving runtime polymorphism.', 5),
(17, 'C++', 'Define operator overloading in C++ and provide examples of its usage.', 5),
(18, 'C++', 'Discuss exception handling mechanisms in C++, including try, catch, and throw statements.', 5),
(19, 'C++', 'Provide an overview of the STL in C++ and discuss its key components, such as containers, iterators, and algorithms.', 5),
(20, 'C++', 'Explain file handling operations in C++, including reading from and writing to files using file streams.', 5),
(21, 'C++', 'Write a C++ function to multiply two matrices of size m x n and n x p.', 10),
(22, 'C++', 'Write a C++ function to count the number of vowels and consonants in a given string.', 10),
(23, 'C++', 'Write a C++ program to sort an array of integers using the merge sort algorithm.', 10),
(24, 'C++', 'Write a C++ program to sort an array of integers using the insertion sort algorithm.', 10),
(25, 'C++', 'Write a C++ function to reverse a singly linked list.', 10),
(26, 'C++', 'Implement a binary tree data structure in C++ with basic operations like insertion, deletion, and traversal.', 10),
(27, 'C++', 'Write a C++ function to perform a depth-first search (DFS) traversal on a graph represented as an adjacency matrix.', 10),
(28, 'C++', 'Write a C++ function to perform a breadth-first search (BFS) traversal on a graph represented as an adjacency list.', 10),
(29, 'C++', 'Write a C++ program to sort an array of integers using the selection sort algorithm.', 10),
(30, 'C++', 'Write a C++ function to find the maximum subarray sum in a given array of integers.', 10),
(31, 'C++', 'Explain the concept of inheritance in C++ and discuss its types and advantages.', 5),
(32, 'C++', 'Define polymorphism in C++ and discuss its types: compile-time and runtime polymorphism.', 5),
(33, 'C++', 'Discuss encapsulation in C++ and explain how it helps in achieving data hiding and abstraction.', 5),
(34, 'C++', 'Describe dynamic memory allocation in C++ using `new` and `delete` operators and discuss its advantages and drawbacks.', 5),
(35, 'C++', 'Define constructors and destructors in C++ and explain their roles in object initialization and cleanup.', 5),
(36, 'C++', 'Explain function overloading in C++ and provide examples to demonstrate its usage.', 5),
(37, 'C++', 'Discuss templates in C++ and explain their role in generic programming.', 5),
(38, 'C++', 'Compare call by value and call by reference in C++ and discuss their implications on function parameter passing.', 5),
(39, 'C++', 'Explain friend functions in C++ and discuss their usage and benefits.', 5),
(40, 'C++', 'Describe exception handling mechanisms in C++ using `try`, `catch`, and `throw` blocks and discuss their importance in error handling.', 5),
(41, 'Python', 'Write a Python function to calculate the factorial of a non-negative integer using recursion. Ensure your function handles non-negative integers and returns the correct factorial value.', 10),
(42, 'Python', 'Create a Python function to check if a given string is a palindrome. The function should return True if the string is a palindrome and False otherwise.', 10),
(43, 'Python', 'Implement a Python function to check if a given integer is a prime number. The function should return True if the number is prime and False otherwise.', 10),
(44, 'Python', 'Write a Python function that calculates the sum of all elements in a list of integers. The function should take the list as input and return the sum.', 10),
(45, 'Python', 'Implement a Python function to perform linear search in a list of integers. The function should take the list and the target value as input parameters and return the index of the target value if found, or -1 otherwise.', 10),
(46, 'Python', 'Write a Python function to sort a list of integers using the bubble sort algorithm. The function should take the list as input and sort it in non-decreasing order.', 10),
(47, 'Python', 'Implement a Python function to generate the Fibonacci sequence up to a given limit. The function should take the limit as input and return a list containing the Fibonacci numbers.', 10),
(48, 'Python', 'Write a Python function to multiply two matrices represented as nested lists. The function should take two matrices and their dimensions as input parameters and return the resulting matrix.', 10),
(49, 'Python', 'Implement a stack data structure in Python using lists. Define methods for push, pop, and peek operations, and ensure the stack behaves correctly under all circumstances.', 10),
(50, 'Python', 'Implement a queue data structure in Python using collections.deque. Define methods for enqueue, dequeue, and peek operations, and ensure the queue behaves correctly under all circumstances.', 10),
(51, 'Python', 'Describe the concept of recursion in Python programming. Provide an example and explain how recursion works, including base cases and recursive calls.', 5),
(52, 'Python', 'Explain the concept of time complexity in algorithms. Discuss common time complexity classes such as O(1), O(n), O(log n), and O(n^2), and provide examples of algorithms that belong to each class.', 5),
(53, 'Python', 'Define data structures and discuss their importance in computer science. Provide examples of common data structures such as arrays, linked lists, stacks, queues, trees, and graphs, and explain their characteristics and use cases.', 5),
(54, 'Python', 'Discuss various sorting algorithms such as bubble sort, selection sort, insertion sort, merge sort, and quick sort. Compare their time complexity, space complexity, and best, average, and worst-case scenarios.', 5),
(55, 'Python', 'Explain different search algorithms such as linear search, binary search, and depth-first search (DFS) and breadth-first search (BFS). Discuss their time complexity, space complexity, and application scenarios.', 5),
(56, 'Python', 'Define object-oriented programming (OOP) and discuss its principles, including encapsulation, inheritance, and polymorphism. Provide examples of classes, objects, and inheritance in Python.', 5),
(57, 'Python', 'Describe Python\'s built-in functions such as len(), range(), map(), filter(), and zip(). Explain their usage, parameters, and return values with examples.', 5),
(58, 'Python', 'Discuss the concept of exception handling in Python programming. Explain try-except blocks, raise statements, and finally blocks, and provide examples of handling different types of exceptions.', 5),
(59, 'Python', 'Define generators and iterators in Python and explain their differences. Discuss the use of yield keyword in generators and the iter() and next() functions in iterators with examples.', 5),
(60, 'Python', 'Explain the concepts of modules and packages in Python. Discuss how modules and packages help in organizing and reusing code, and provide examples of importing modules and packages in Python programs.', 5),
(61, 'Python', 'Write a Python function to check if two strings are anagrams of each other. Anagrams are words or phrases that contain the same characters but in a different order.', 10),
(62, 'Python', 'Implement a Python function to compute the transpose of a given matrix. The transpose of a matrix flips the matrix over its diagonal.', 10),
(63, 'Python', 'Write a Python function to perform binary search in a sorted list of integers. The function should take the list and the target value as input parameters and return the index of the target value if found, or -1 otherwise.', 10),
(64, 'Python', 'Implement a Python function to sort a list of integers using the selection sort algorithm. The function should take the list as input and sort it in non-decreasing order.', 10),
(65, 'Python', 'Write a Python function to sort a stack of integers using only one additional stack. The function should take the unsorted stack as input and return the sorted stack.', 10),
(66, 'Python', 'Implement a Python function to reverse the elements of a queue. The function should take the queue as input and reverse its order without using any additional data structures.', 10),
(67, 'Python', 'Write a Python function to find the subarray with the largest sum in a given array of integers. The function should return the sum of the largest subarray.', 10),
(68, 'Python', 'Implement a Python function to reverse a singly linked list. The function should take the head of the linked list as input and return the head of the reversed list.', 10),
(69, 'Python', 'Write a Python function to merge two sorted linked lists into a single sorted linked list. The function should take the heads of the two lists as input and return the head of the merged list.', 10),
(70, 'Python', 'Implement Python functions for pre-order, in-order, and post-order traversals of a binary tree. Each function should take the root of the tree as input and perform the respective traversal.', 10),
(71, 'Python', 'Explain the concept of Big O notation in algorithm analysis. Discuss its significance in measuring the time complexity of algorithms and provide examples of common Big O notations.', 5),
(72, 'Python', 'Discuss the concept of space complexity in algorithm analysis. Explain how space complexity is different from time complexity and provide examples of algorithms with different space complexities.', 5),
(73, 'Python', 'Define abstract data types (ADTs) and discuss their role in software development. Provide examples of common ADTs such as lists, stacks, queues, and trees, and explain how they are implemented and used.', 5),
(74, 'Python', 'Explain different graph traversal algorithms such as depth-first search (DFS) and breadth-first search (BFS). Discuss their applications in graph theory and computer science.', 5),
(75, 'Python', 'Discuss the concept of dynamic programming in algorithm design. Explain how dynamic programming is used to solve optimization problems and provide examples of problems that can be solved using dynamic programming.', 5),
(76, 'Python', 'Define hash tables and discuss their implementation and use cases. Explain how hash functions work and how collisions are handled in hash tables.', 5),
(77, 'Python', 'Discuss the properties of trees in graph theory. Explain concepts such as height, depth, level, degree, and balance factor in the context of trees.', 5),
(78, 'Python', 'Explain the concept of greedy algorithms in algorithm design. Discuss the greedy-choice property and the optimal substructure property, and provide examples of problems solved using greedy algorithms.', 5),
(79, 'Python', 'Discuss the concept of backtracking algorithms in algorithm design. Explain how backtracking is used to solve problems by generating candidates and making choices, and provide examples of problems that can be solved using backtracking.', 5),
(80, 'Python', 'Define concurrency and parallelism in computer science. Explain the differences between concurrent and parallel execution, and discuss their applications in software development.', 5),
(81, 'Python', 'Write a Python function to detect if a linked list has a cycle. If a cycle is found, return True; otherwise, return False.', 10),
(82, 'Python', 'Implement a Python function to find the diameter of a binary tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree.', 10),
(83, 'Python', 'Write a Python function to find the length of the longest common subsequence between two given strings. A subsequence is a sequence that appears in the same relative order but not necessarily contiguous.', 10),
(84, 'Python', 'Implement a Python function to partition a string into as many palindrome substrings as possible. Return all possible palindrome partitioning of the input string.', 10),
(85, 'Python', 'Write a Python function to merge overlapping intervals. Given a collection of intervals, merge all overlapping intervals and return the result.', 10),
(86, 'Python', 'Implement a Python function to find the maximum product of a contiguous subarray within an array of integers.', 10),
(87, 'Python', 'Write a Python function to find the minimum depth of a binary tree. The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.', 10),
(88, 'Python', 'Implement a Python function to convert a sorted array into a height-balanced binary search tree (BST).', 10),
(89, 'Python', 'Write a Python function to determine if a given binary tree is a valid binary search tree (BST). A valid BST is defined as follows: The left subtree of a node contains only nodes with keys less than the node\'s key, and the right subtree contains only nodes with keys greater than the node\'s key.', 10),
(90, 'Python', 'Implement a Python function to perform topological sorting on a directed acyclic graph (DAG). Return a list of vertices in topological order.', 10),
(91, 'Python', 'Explain how memory management works in Python. Discuss concepts such as reference counting, garbage collection, and memory allocation strategies.', 5),
(92, 'Python', 'Define decorator functions in Python. Explain their purpose and how they are used to modify the behavior of other functions.', 5),
(93, 'Python', 'Discuss asynchronous programming in Python using async/await syntax. Explain how asynchronous programming differs from synchronous programming and its benefits.', 5),
(94, 'Python', 'Define regular expressions in Python. Discuss their importance and applications in text processing, pattern matching, and data validation.', 5),
(95, 'Python', 'Explain the concept of data serialization in Python. Discuss popular serialization formats such as JSON, XML, and Pickle, and their use cases.', 5),
(96, 'Python', 'Discuss different concurrency models in Python, including threads, processes, and coroutines. Compare their advantages, disadvantages, and use cases.', 5),
(97, 'Python', 'Define unit testing in Python. Discuss popular unit testing frameworks such as unittest and pytest, and explain how unit tests are written and executed.', 5),
(98, 'Python', 'Discuss popular web frameworks in Python, such as Flask, Django, and FastAPI. Compare their features, advantages, and use cases.', 5),
(99, 'Python', 'Explain the process of packaging and distributing Python projects. Discuss tools such as setuptools, pip, and virtualenv, and best practices for creating distributable Python packages.', 5),
(100, 'Python', 'Discuss how to extend Python with C extensions. Explain the process of writing and compiling C code for use in Python, and when it\'s appropriate to use C extensions.', 5),
(163, 'C#', 'What is the purpose of the \'using\' statement in C#?', 5),
(164, 'C#', 'Explain the difference between \'ref\' and \'out\' parameters in C#.', 5),
(165, 'C#', 'What is a delegate in C#?', 5),
(166, 'C#', 'How do you handle exceptions in C#?', 5),
(167, 'C#', 'What are the differences between a class and a struct in C#?', 5),
(168, 'C#', 'How do you implement inheritance in C#?', 5),
(169, 'C#', 'What is the difference between \'==\' and \'.Equals()\' in C#?', 5),
(170, 'C#', 'What is the purpose of the \'var\' keyword in C#?', 5),
(171, 'C#', 'Explain the concept of \'boxing\' and \'unboxing\' in C#.', 5),
(172, 'C#', 'What are the different access modifiers in C#?', 5),
(173, 'C#', 'How do you implement polymorphism in C#?', 5),
(174, 'C#', 'What is a lambda expression in C#?', 5),
(175, 'C#', 'Explain the \'async\' and \'await\' keywords in C#.', 5),
(176, 'C#', 'How do you work with collections in C#?', 5),
(177, 'C#', 'What are extension methods in C#?', 5),
(178, 'C#', 'What is LINQ and how do you use it in C#?', 5),
(179, 'C#', 'Explain the concept of garbage collection in C#.', 5),
(180, 'C#', 'What is a constructor in C# and how is it used?', 5),
(181, 'C#', 'How do you implement interfaces in C#?', 5),
(182, 'C#', 'Explain the difference between \'IEnumerable\' and \'IQueryable\' in C#.', 5),
(195, 'C#', 'What is the purpose of the \'using\' ', 10);

-- --------------------------------------------------------

--
-- Table structure for table `submission`
--

CREATE TABLE `submission` (
  `SubmissionID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  `Marks` int(11) DEFAULT NULL,
  `SubmissionTime` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `phone`, `password`) VALUES
(12, 'AbdulHannan', 'abdulhannan03086@gmail.com', '03219188918', '03086844505');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`QuestionID`);

--
-- Indexes for table `submission`
--
ALTER TABLE `submission`
  ADD PRIMARY KEY (`SubmissionID`),
  ADD KEY `UserID` (`UserID`),
  ADD KEY `QuestionID` (`QuestionID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `question`
--
ALTER TABLE `question`
  MODIFY `QuestionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=196;

--
-- AUTO_INCREMENT for table `submission`
--
ALTER TABLE `submission`
  MODIFY `SubmissionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `submission`
--
ALTER TABLE `submission`
  ADD CONSTRAINT `submission_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `submission_ibfk_2` FOREIGN KEY (`QuestionID`) REFERENCES `question` (`QuestionID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
