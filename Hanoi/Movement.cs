using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hanoi
{
    public partial class MainWindow : Window
    {
        // This partial class handles the movement of the elements from one to another rod.
        
        /* First, an element is poped out of its stack. 
        * Before it can moved, it must be checked if one of the three rules is violated:
            * 1. Only one disk can be moved among the towers at any given time.
            * 2. Only the "top" disk can be removed.
            * 3. No large disk can sit over a small disk.
        *  The first and the second rule is satisfied automatically because a stack is used as data structure.
        *  The third rule is more challenging. So it has to be checked if the destination stack is empty or posses already an element.
        * After that, the movement operation is assigned and the rectangle is moved.
        * Before pushin in the new stack, the vertical position has to be checked and adjusted.
        * At the end, the relevant stack is pushed */
        public void From_Start_to_Support()
        {
            if (Stack_Start.Count != 0)
            {
                tmp_element = Stack_Start.Pop();
                operation = Operation.start_to_support;
                destination_stackpos = StackPos.position_support;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Support.Pop();
                    Stack_Support.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Start.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Support.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Support.Push(tmp_element);
                }
            }
        }

        public void From_Support_to_Destination()
        {
            if (Stack_Support.Count != 0)
            {                
                tmp_element = Stack_Support.Pop();
                operation = Operation.support_to_destination;
                destination_stackpos = StackPos.position_destination;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Destination.Pop();
                    Stack_Destination.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Support.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Destination.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Destination.Push(tmp_element);
                }
            }
        }

        public void From_Support_to_Start()
        {
            if (Stack_Support.Count != 0)
            {                
                tmp_element = Stack_Support.Pop();
                operation = Operation.support_to_start;
                destination_stackpos = StackPos.position_start;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Start.Pop();
                    Stack_Start.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Support.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Start.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Start.Push(tmp_element);
                }
            }
        }

        public void From_Destination_to_Support()
        {
            if (Stack_Destination.Count != 0)
            {
                
                tmp_element = Stack_Destination.Pop();
                operation = Operation.destination_to_support;
                destination_stackpos = StackPos.position_support;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Support.Pop();
                    Stack_Support.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Destination.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Support.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Support.Push(tmp_element);
                }
            }
        }

        public void From_Start_to_Destination()
        {
            if (Stack_Start.Count != 0)
            {

                tmp_element = Stack_Start.Pop();
                operation = Operation.start_to_destination;
                destination_stackpos = StackPos.position_destination;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Destination.Pop();
                    Stack_Destination.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Start.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Destination.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Destination.Push(tmp_element);
                }
            }
        }

        public void From_Destination_to_Start()
        {
            if (Stack_Destination.Count != 0)
            {

                tmp_element = Stack_Destination.Pop();
                operation = Operation.destination_to_start;
                destination_stackpos = StackPos.position_start;
                i_tmp = Check_stack_counter(destination_stackpos);
                if (i_tmp != 0)
                {
                    // If temp_int is not zero, the stack must hold other elements. 
                    // Now it must be checked if the element before is larger than the actual element. 
                    // actual element == tmp_element
                    // element before == tmp_element2
                    tmp_element2 = Stack_Start.Pop();
                    Stack_Start.Push(tmp_element2);
                    // Compare elements
                    if (!Compare_elements())
                    {
                        // The element before is smaller. Operation is not allowed.
                        MessageBox.Show("This operation is not allowed:\nNo large disk can sit over a small disk.");
                        Stack_Destination.Push(tmp_element);
                    }
                    else
                    {
                        // Operation is allowed
                        Move(operation, destination_stackpos);
                        Stack_Start.Push(tmp_element);
                    }
                }
                else
                {
                    Move(operation, destination_stackpos);
                    Stack_Start.Push(tmp_element);
                }
            }
        }
    }
}
