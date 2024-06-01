using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WinFormsApp1;

namespace WinFormsApp1
{
    static class RPN
    {
        private static Form1 form;
        private static string seq;
        public static void calculate_rpn(string expression, Form1 f)
        {
            form = f;
            seq = expression;

            Stack<string> stack = new Stack<string>();
            string num = "";
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c)) num += c; // если цифра - добавляем к числу
                else if (c == ';' && num != "") // если разделитель - добавляем число в стек и обнуляем
                {
                    stack.Push(num);
                    num = "";
                }
                else if (is_operator(c) && i + 1 == expression.Length)
                { // если оператор - пытаемся выполнить команду
                    apply(stack, c);
                }
                else num += c;
            }
        }

        private static bool is_operator(char c)
        {
            return c == 'C' || c == 'M' || c == 'D';
        }

        private static void apply(Stack<string> operands, char c)
        {
            if (c == 'C' && operands.Count == 5)
            {
                bool state = true;
                string name = operands.Pop();

                for (int i = 0; i < ShapeContainer.length; i++)
                {
                    if (ShapeContainer.figureList[i].name == name) state = false;
                }
                if (state)
                {
                    if (int.TryParse(operands.Pop(), out int h) && int.TryParse(operands.Pop(), out int w) && int.TryParse(operands.Pop(), out int y) && int.TryParse(operands.Pop(), out int x))
                    {

                        MessageBox.Show($"{x} {y} {w} {h}");

                        Cat cat = new Cat(h, w, name, y, x);
                        if (cat.move_check(0, 0))
                        {
                            cat.draw();
                            form.listBox1.Items.Add($"{seq} - Выполнено");
                            ShapeContainer.AddFigure(cat);
                        }
                        else form.listBox1.Items.Add($"{seq} - Ошибка(неверные координаты)");
                    }
                    else form.listBox1.Items.Add($"{seq} - Ошибка(неверный формат)");
                }
                else form.listBox1.Items.Add($"{seq} - Ошибка(неверное имя)");
            }
            else if (c == 'M' && operands.Count == 3)
            {
                string name = operands.Pop();
                bool state = false;
                int index = 0;

                for (int i = 0; i < ShapeContainer.length; i++)
                {
                    if (name == ShapeContainer.figureList[i].name)
                    {
                        index = i;
                        state = true;
                        break;
                    }
                }

                if (state)
                {
                    if (int.TryParse(operands.Pop(), out int y) && int.TryParse(operands.Pop(), out int x))
                    {
                        Figure f = ShapeContainer.figureList[index];
                        if (f.move_check(x, y))
                        {
                            f.move_to(x, y);
                            form.listBox1.Items.Add($"{seq} - Выполнено");
                        }
                        else form.listBox1.Items.Add($"{seq} - Ошибка(неверные координаты");
                    }
                    else form.listBox1.Items.Add($"{seq} - Ошибка(неверный формат)");
                }
                else form.listBox1.Items.Add($"{seq} - Ошибка(неверное имя)");
            }
            else if (c == 'D')
            {
                string name = operands.Pop();
                bool state = false;

                for (int i = 0; i < ShapeContainer.length; i++)
                {
                    if (name == ShapeContainer.figureList[i].name)
                    {
                        Figure f = ShapeContainer.figureList[i];
                        f.drop_figure(f);
                        form.listBox1.Items.Add($"{seq} - Выполнено");
                        state = true;
                        break;
                    }
                }
                if (state == false) form.listBox1.Items.Add($"{seq} - Ошибка(неверное имя)");
            }
            else form.listBox1.Items.Add("Ошибка");
        }
    }
}
