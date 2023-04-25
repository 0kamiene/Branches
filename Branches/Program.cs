using System;

//Family Tree branches
class familyMember
{
    public string Name;
    public List<familyMember> children;

    public familyMember(string name)
    {
        Name = name;
        children = new List<familyMember>();
    }

    public void AddChild(familyMember child)
    {
        children.Add(child);
    }
}

//Calculation
class Program
{
    static int calculateDepth(familyMember member)
    {
        if (member == null)
        {
            return 0;
        }
        else
        {
            int maxChildDepth = 0;
            foreach (familyMember child in member.children)
            {
                int childDepth = calculateDepth(child);
                if (childDepth > maxChildDepth)
                {
                    maxChildDepth = childDepth;
                }
            }
            return maxChildDepth + 1;
        }
    }

    static void Main(string[] args)
    {
        // Create a family tree.
        familyMember grandParent = new familyMember("Grandparent");
        familyMember parent1 = new familyMember("Parent 1");
        familyMember parent2 = new familyMember("Parent 2");
        familyMember child1 = new familyMember("Child 1");
        familyMember child2 = new familyMember("Child 2");
        familyMember child3 = new familyMember("Child 3");
        grandParent.AddChild(parent1);
        grandParent.AddChild(parent2);
        parent1.AddChild(child1);
        parent1.AddChild(child2);
        parent2.AddChild(child3);

        // Calculate the depth of the family tree.
        int depth = calculateDepth(grandParent);
        Console.WriteLine("The depth of the family tree is: " + depth);
        Console.WriteLine(grandParent);
    }
}
//    Visual Representation

//         Grandparent                  1 depth
//          /      \
//     Parent 1     Parent 2            2 depth
//      /    \          \
// Child 1  Child 2   Child 3           3 depth