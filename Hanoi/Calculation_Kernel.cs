using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Hanoi
{
    public partial class MainWindow : Window
    {
        /* The following rules apply:
         * 
         *  Only one disk can be moved among the towers at any given time.
         *  Only the "top" disk can be removed.
         *  No large disk can sit over a small disk.
         *  
         */
        public System.Collections.Stack Stack_Start = new System.Collections.Stack();
        public System.Collections.Stack Stack_Support = new System.Collections.Stack();
        public System.Collections.Stack Stack_Destination = new System.Collections.Stack();

        //Two objects tmp are created to be used as temporary storage
        public Object tmp_element;
        public Object tmp_element2;
        //x_diff is the distance difference between the towers
        public double x_dif = 220;
        // Position on the canvas starting from the top.
        public int y_settop0 = 300;
        public int y_settop1 = 260;
        public int y_settop2 = 220;
        public int y_settop3 = 180;
        public int y_settop4 = 140;
        // Temporary integer:
        public int i_tmp = 0;

        //The created enum "Operation" is used to control performed movements of the stack elements
        public enum Operation
        {
            start_to_support, support_to_start, support_to_destination, destination_to_support, start_to_destination, destination_to_start
            //These names basically refer to the values 0, 1, 2, 3, 4, 5
        }
        Operation operation = Operation.start_to_support;

        //The created enum "StackPos" is used to control performed movements of the stack elements in their vertical direction
        public enum StackPos
        {
            position_start, position_support, position_destination
            //These names basically refer to the values 0, 1, 2
        }
        StackPos destination_stackpos = StackPos.position_start;  

        public void Initialize_Hanoi()
        {
            /* 
             * The function start_hanoi starts with placing the parts on the left side. It also initializes all three stacks. 
             * Placing elements on the canvas starting from the left side.
             */
            int x_setleft = 50;
            Canvas.SetLeft(r_Large0, x_setleft);
            Canvas.SetLeft(r_MidLarge1, x_setleft += 15);
            Canvas.SetLeft(r_Mid2, x_setleft += 15);
            Canvas.SetLeft(r_Small3, x_setleft += 15);
            Canvas.SetLeft(r_Small4, x_setleft += 15);

            // Place the elements on the canvas starting from the top.
            Canvas.SetTop(r_Large0, y_settop0);
            Canvas.SetTop(r_MidLarge1, y_settop1);
            Canvas.SetTop(r_Mid2, y_settop2);
            Canvas.SetTop(r_Small3, y_settop3);
            Canvas.SetTop(r_Small4, y_settop4);

            // All elements are inserted via stack-operations in the right order in the left stack.
            // It is very important to clear the stack before using it!
            Stack_Start.Clear();
            Stack_Start.Push(r_Large0);
            Stack_Start.Push(r_MidLarge1);
            Stack_Start.Push(r_Mid2);
            Stack_Start.Push(r_Small3);
            Stack_Start.Push(r_Small4);

            // Makes sure that the other stack are empty at the beginning.
            Stack_Support.Clear();
            Stack_Destination.Clear();            
            
        }
       
        public void Move(Operation temp_op, StackPos temp_stackpos)
        {
            Move_horizontally(temp_op);
            Move_vertically(temp_stackpos);
        }

        public void Move_horizontally(Operation temp_op)
        {
            /*
             * The following lines realize the movement of the individual elements with respect to the rules. 
             * If the stack is empty, the element will be placed at the bottom. 
             * If stack is not empty, it will be placed above the upper element of the stack. 
             * In order to do that, the method rectangle_move needs to take the operation "temp_op", which sould be performed, 
             * and the object "temp_object", that should be moved.
             */
            double x_tmp;
            if (temp_op.Equals(Operation.start_to_support) || temp_op.Equals(Operation.support_to_destination))
            {
                x_tmp = x_dif;
            }
            else if(temp_op.Equals(Operation.start_to_destination))
            {
                x_tmp = x_dif * 2;
            }
            else if (temp_op.Equals(Operation.destination_to_start))
            {
                x_tmp = -x_dif * 2;
            }
            else
            {
                x_tmp = -x_dif;
            }
            /* 
             * This lines basically ask if the movement goes right 
             * and if that is not true, than it goes left. 
             * Special are the cases for start to destination and vice versa.
             * They need the double distance value.
             */

            /* These are the cases for the individual elements. 
             * They are moved depending on the direction given by x_dif (+/-=right/left)
             * It should be noted that this is only the horizontal movement, 
             * not the movement in die vertical direction.
             */

            if (tmp_element.Equals(r_Small4))
            {
                Canvas.SetLeft(r_Small4, Canvas.GetLeft(r_Small4) + x_tmp);
            }
            else if (tmp_element.Equals(r_Small3))
            {
                Canvas.SetLeft(r_Small3, Canvas.GetLeft(r_Small3) + x_tmp);
            }
            else if (tmp_element.Equals(r_Mid2))
            {
                Canvas.SetLeft(r_Mid2, Canvas.GetLeft(r_Mid2) + x_tmp);
            }
            else if (tmp_element.Equals(r_MidLarge1))
            {
                Canvas.SetLeft(r_MidLarge1, Canvas.GetLeft(r_MidLarge1) + x_tmp);
            }
            else if (tmp_element.Equals(r_Large0))
            {
                Canvas.SetLeft(r_Large0, Canvas.GetLeft(r_Large0) + x_tmp);
            }
        }

        public void Move_vertically(StackPos temp_stackpos)
        {
            // At each stack there are four possible vertical position. 
            // The following lines check and set the right height of each moved element.
            switch (Check_stack_counter(temp_stackpos))
            {
                case 0:
                    Set_vertical_position(y_settop0);
                    break;
                case 1:
                    Set_vertical_position(y_settop1);
                    break;
                case 2:
                    Set_vertical_position(y_settop2);
                    break;
                case 3:
                    Set_vertical_position(y_settop3);
                    break;
                case 4:
                    Set_vertical_position(y_settop4);
                    break;
                default:
                    break;
            }
        }

        public void Set_vertical_position(int y_pos)
        {
            // Checking these properties is not so easy because it is hard to bind a property to an xaml object.
            if (tmp_element.Equals(r_Small4))
            {
                Canvas.SetTop(r_Small4, y_pos);
            }
            else if (tmp_element.Equals(r_Small3))
            {
                Canvas.SetTop(r_Small3, y_pos);
            }
            else if (tmp_element.Equals(r_Mid2))
            {
                Canvas.SetTop(r_Mid2, y_pos);
            }
            else if (tmp_element.Equals(r_MidLarge1))
            {
                Canvas.SetTop(r_MidLarge1, y_pos);
            }
            else if (tmp_element.Equals(r_Large0))
            {
                Canvas.SetTop(r_Large0, y_pos);
            }
        }

        public bool Compare_elements()
        {
            // It follows a very simple way of comparing two elements and 
            // getting the result that the element before is larger than the actual element.
            int i_tmp_element = 0;
            int i_tmp_element2 = 0;

            // First element
            i_tmp_element = Compare_one_element(tmp_element);
            
            // Second element
            i_tmp_element2 = Compare_one_element(tmp_element2);
            
            return (i_tmp_element2 > i_tmp_element);
        }

        public int Compare_one_element(Object o_temp)
        {
            int i_temp;
            if (o_temp.Equals(r_Small4))
            {
                i_temp = 1;
            }
            else if (o_temp.Equals(r_Small3))
            {
                i_temp = 2;
            }
            else if (o_temp.Equals(r_Mid2))
            {
                i_temp = 3;
            }
            else if (o_temp.Equals(r_MidLarge1))
            {
                i_temp = 4;
            }
            else if (o_temp.Equals(r_Large0))
            {
                i_temp = 5;
            }
            else
            {
                i_temp = 0;
            }
            return i_temp;
        }

        public int Check_stack_counter(StackPos temp_stackpos)
        {
            // The following lines check which number of elements a stack holds.
            int count = 0;
            switch (temp_stackpos)
            {
                case StackPos.position_start:
                    count = Stack_Start.Count;
                    break;
                case StackPos.position_support:
                    count = Stack_Support.Count;
                    break;
                case StackPos.position_destination:
                    count = Stack_Destination.Count;
                    break;
            }
            return count;
        }

    }
}
