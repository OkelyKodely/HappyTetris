using System;

using System.Threading;

using System.Drawing;

using System.Windows.Forms;

using System.Collections.Generic;


class Titrus
{

    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

    GifImage gibg = new GifImage(Environment.CurrentDirectory + "\\block.gif");

    GifImage gi = new GifImage(Environment.CurrentDirectory + "\\bg.gif");

    int score = 0;
    
    From frame = null;
    Pnel panel = new Pnel();
    
    List<Block> squares = new List<Block>();

    Titrus()
    {
        frame = new From(this, wplayer);
        frame.Text = "Score: " + score;

        frame.FormBorderStyle = FormBorderStyle.FixedSingle;

        frame.MaximizeBox = false;
        frame.MinimizeBox = false;
        
        frame.SetBounds(0, 0, 520, 740);
        panel.SetBounds(frame.Bounds.X, frame.Bounds.Y, frame.Bounds.Width, frame.Bounds.Height);
        frame.Controls.Add(panel);

        play();

    }

    private void addBrandNewBlocks()
    {
        Random random = new Random();

        int option = random.Next(7) + 1;

        Block block1 = new Block();
        Block block2 = new Block();
        Block block3 = new Block();
        Block block4 = new Block();

        block1.setInfo("pointing", "up");
        block2.setInfo("pointing", "up");
        block3.setInfo("pointing", "up");
        block4.setInfo("pointing", "up");

        if (option == 3)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "hat");
            squares.Add(block1);

            block2.set("x", 200);
            block2.set("y", 50);
            block2.setInfo("type", "hat");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 50);
            block3.setInfo("type", "hat");
            squares.Add(block3);

            block4.set("x", 300);
            block4.set("y", 50);
            block4.setInfo("type", "hat");
            squares.Add(block4);
        }
        else if (option == 1)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "line");
            squares.Add(block1);

            block2.set("x", 250);
            block2.set("y", 50);
            block2.setInfo("type", "line");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 100);
            block3.setInfo("type", "line");
            squares.Add(block3);

            block4.set("x", 250);
            block4.set("y", 150);
            block4.setInfo("type", "line");
            squares.Add(block4);
        }
        else if (option == 2)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "square");
            squares.Add(block1);

            block2.set("x", 300);
            block2.set("y", 0);
            block2.setInfo("type", "square");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 50);
            block3.setInfo("type", "square");
            squares.Add(block3);

            block4.set("x", 300);
            block4.set("y", 50);
            block4.setInfo("type", "square");
            squares.Add(block4);
        }
        else if (option == 4)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "ls");
            squares.Add(block1);

            block2.set("x", 200);
            block2.set("y", 50);
            block2.setInfo("type", "ls");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 50);
            block3.setInfo("type", "ls");
            squares.Add(block3);

            block4.set("x", 200);
            block4.set("y", 100);
            block4.setInfo("type", "ls");
            squares.Add(block4);
        }
        else if (option == 5)
        {
            block1.set("x", 200);
            block1.set("y", 0);
            block1.setInfo("type", "rs");
            squares.Add(block1);

            block2.set("x", 200);
            block2.set("y", 50);
            block2.setInfo("type", "rs");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 50);
            block3.setInfo("type", "rs");
            squares.Add(block3);

            block4.set("x", 250);
            block4.set("y", 100);
            block4.setInfo("type", "rs");
            squares.Add(block4);
        }
        else if (option == 6)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "la");
            squares.Add(block1);

            block2.set("x", 250);
            block2.set("y", 50);
            block2.setInfo("type", "la");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 100);
            block3.setInfo("type", "la");
            squares.Add(block3);

            block4.set("x", 200);
            block4.set("y", 100);
            block4.setInfo("type", "la");
            squares.Add(block4);
        }
        else if (option == 7)
        {
            block1.set("x", 250);
            block1.set("y", 0);
            block1.setInfo("type", "ra");
            squares.Add(block1);

            block2.set("x", 250);
            block2.set("y", 50);
            block2.setInfo("type", "ra");
            squares.Add(block2);

            block3.set("x", 250);
            block3.set("y", 100);
            block3.setInfo("type", "ra");
            squares.Add(block3);

            block4.set("x", 300);
            block4.set("y", 100);
            block4.setInfo("type", "ra");
            squares.Add(block4);
        }
    }

    void play()
    {
        addBrandNewBlocks();

        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        timer1.Interval = 91;
        timer1.Tick += new EventHandler(timer1_Tick);
        timer1.Start();

        System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
        timer2.Interval = 1000;
        timer2.Tick += new EventHandler(timer2_Tick);
        timer2.Start();
    }

    private bool isJuxtaposedLeft()
    {
        for (int i = squares.Count - 4; i < squares.Count; i++)
        {
            for (int j = 0; squares.Count != 4 && j < squares.Count - 4; j++)
            {
                if (squares[i].get("x") + 50 == squares[j].get("x") && squares[i].get("y") == squares[j].get("y"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool isJuxtaposedRight()
    {
        for (int i = squares.Count - 4; i < squares.Count; i++)
        {
            for (int j = 0; squares.Count != 4 && j < squares.Count - 4; j++)
            {
                if (squares[i].get("x") - 50 == squares[j].get("x") && squares[i].get("y") == squares[j].get("y"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void clearLine()
    {
        List<int> list = new List<int>();

        int count = 0;

        for (int j = 0; j < 740; j += 50)
        {
            for (int i = 0; i < squares.Count - 4; i++)
            {
                if (squares[i].get("y") == j)
                {
                    count++;
                }
                if (count == 10)
                {
                    list.Add(j);
                    break;
                }
            }
            count = 0;
        }
        if (list.Count > 0)
        {
            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < squares.Count - 4; i++)
                {
                    if (squares[i].get("y") == list[j])
                    {
                        squares[i].set("y", 1000);
                    }
                }
                for (int i = 0; i < squares.Count - 4; i++)
                {
                    if (squares[i].get("y") < list[j])
                    {
                        squares[i].set("y", squares[i].get("y") + 50);
                    }
                }
                score = score + 1;
                if (score == 500)
                {
                    MessageBox.Show("Congratulations, You Won!! Your Score: 500!!!!");
                    Application.Exit();
                }
                if (score > 0 && score < 11)
                {
                    wplayer.URL = score + ".mp3";
                    wplayer.controls.play();
                }
                else if (score > 10 && score < 20)
                {
                    wplayer.URL = score + ".mp3";
                    wplayer.controls.play();
                }
                if (score > 19)
                {
                    int val = (score/10) * 10;
                    int val2 = score - val;
                    if (val < 100)
                    {
                        wplayer.URL = val + ".mp3";
                        wplayer.controls.play();
                        new System.Threading.ManualResetEvent(false).WaitOne(750);
                        if (val2 > 0)
                        {
                            wplayer.URL = val2 + ".mp3";
                            wplayer.controls.play();
                        }
                    }
                    else if (score == 100)
                    {
                        wplayer.URL = val + ".mp3";
                        wplayer.controls.play();
                        new System.Threading.ManualResetEvent(false).WaitOne(750);
                    }
                    else if (score > 100)
                    {
                        int val3 = (score / 100) * 100;
                        int val4 = score - val3;
                        wplayer.URL = val3 + ".mp3";
                        wplayer.controls.play();
                        new System.Threading.ManualResetEvent(false).WaitOne(750);
                        if (val4 > 0)
                        {
                            if (val4 < 20)
                            {
                                wplayer.URL = val4 + ".mp3";
                                wplayer.controls.play();
                            }
                            else if (val4 > 19)
                            {
                                int val5 = (val4 / 10) * 10;
                                int val6 = val4 - val5;
                                wplayer.URL = val5 + ".mp3";
                                wplayer.controls.play();
                                new System.Threading.ManualResetEvent(false).WaitOne(750);
                                if (val6 > 0)
                                {
                                    wplayer.URL = val6 + ".mp3";
                                    wplayer.controls.play();
                                }
                            }
                        }
                    }
                }

                frame.Text = "Score: " + score;
            }
        }
    }

    public void rotate()
    {
        wplayer.URL = "rotate.wav";
        wplayer.controls.play();

        Block bl1 = squares[squares.Count - 4];
        Block bl2 = squares[squares.Count - 3];
        Block bl3 = squares[squares.Count - 2];
        Block bl4 = squares[squares.Count - 1];

        if (bl1.getInfo("type").Equals("line")&&
            bl2.getInfo("type").Equals("line")&&
            bl3.getInfo("type").Equals("line")&&
            bl4.getInfo("type").Equals("line"))
        {
            if (bl1.getInfo("pointing").Equals("up")&&
                bl2.getInfo("pointing").Equals("up")&&
                bl3.getInfo("pointing").Equals("up")&&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x") + 150);
                bl1.set("y", bl1.get("y") + 150);
                bl2.set("x", bl2.get("x") + 100);
                bl2.set("y", bl2.get("y") + 100);
                bl3.set("x", bl3.get("x") + 50);
                bl3.set("y", bl3.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x") - 150);
                bl1.set("y", bl1.get("y") + 150);
                bl2.set("x", bl2.get("x") - 100);
                bl2.set("y", bl2.get("y") + 100);
                bl3.set("x", bl3.get("x") - 50);
                bl3.set("y", bl3.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x") - 150);
                bl1.set("y", bl1.get("y") - 150);
                bl2.set("x", bl2.get("x") - 100);
                bl2.set("y", bl2.get("y") - 100);
                bl3.set("x", bl3.get("x") - 50);
                bl3.set("y", bl3.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x") + 150);
                bl1.set("y", bl1.get("y") - 150);
                bl2.set("x", bl2.get("x") + 100);
                bl2.set("y", bl2.get("y") - 100);
                bl3.set("x", bl3.get("x") + 50);
                bl3.set("y", bl3.get("y") - 50);
            }
        }
        else if (bl1.getInfo("type").Equals("hat") &&
            bl2.getInfo("type").Equals("hat") &&
            bl3.getInfo("type").Equals("hat") &&
            bl4.getInfo("type").Equals("hat"))
        {
            if (bl1.getInfo("pointing").Equals("up") &&
                bl2.getInfo("pointing").Equals("up") &&
                bl3.getInfo("pointing").Equals("up") &&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x") + 50);
                bl1.set("y", bl1.get("y") + 50);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x") - 50);
                bl1.set("y", bl1.get("y") + 50);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x") - 50);
                bl1.set("y", bl1.get("y") - 50);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x") + 50);
                bl1.set("y", bl1.get("y") - 50);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") + 50);
            }
        }
        else if (bl1.getInfo("type").Equals("ls") &&
            bl2.getInfo("type").Equals("ls") &&
            bl3.getInfo("type").Equals("ls") &&
            bl4.getInfo("type").Equals("ls"))
        {
            if (bl1.getInfo("pointing").Equals("up") &&
                bl2.getInfo("pointing").Equals("up") &&
                bl3.getInfo("pointing").Equals("up") &&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x"));
                bl1.set("y", bl1.get("y") + 100);
                bl3.set("x", bl3.get("x") - 50);
                bl3.set("y", bl3.get("y") + 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y"));
                bl3.set("x", bl3.get("x") - 50);
                bl3.set("y", bl3.get("y") - 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x"));
                bl1.set("y", bl1.get("y") - 100);
                bl3.set("x", bl3.get("x") + 50);
                bl3.set("y", bl3.get("y") - 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y"));
                bl3.set("x", bl3.get("x") + 50);
                bl3.set("y", bl3.get("y") + 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") + 50);
            }
        }
        else if (bl1.getInfo("type").Equals("ra") &&
            bl2.getInfo("type").Equals("ra") &&
            bl3.getInfo("type").Equals("ra") &&
            bl4.getInfo("type").Equals("ra"))
        {
            if (bl1.getInfo("pointing").Equals("up") &&
                bl2.getInfo("pointing").Equals("up") &&
                bl3.getInfo("pointing").Equals("up") &&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y") + 100);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y") + 100);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y") - 100);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y") - 100);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") + 50);
            }
        }
        else if (bl1.getInfo("type").Equals("la") &&
            bl2.getInfo("type").Equals("la") &&
            bl3.getInfo("type").Equals("la") &&
            bl4.getInfo("type").Equals("la"))
        {
            if (bl1.getInfo("pointing").Equals("up") &&
                bl2.getInfo("pointing").Equals("up") &&
                bl3.getInfo("pointing").Equals("up") &&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y") + 100);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y") + 100);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y") - 100);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y") - 100);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") - 50);
            }
        }
        else if (bl1.getInfo("type").Equals("rs") &&
            bl2.getInfo("type").Equals("rs") &&
            bl3.getInfo("type").Equals("rs") &&
            bl4.getInfo("type").Equals("rs"))
        {
            if (bl1.getInfo("pointing").Equals("up") &&
                bl2.getInfo("pointing").Equals("up") &&
                bl3.getInfo("pointing").Equals("up") &&
                bl4.getInfo("pointing").Equals("up"))
            {
                bl1.setInfo("pointing", "right");
                bl2.setInfo("pointing", "right");
                bl3.setInfo("pointing", "right");
                bl4.setInfo("pointing", "right");

                bl1.set("x", bl1.get("x") + 100);
                bl1.set("y", bl1.get("y"));
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("right") &&
                bl2.getInfo("pointing").Equals("right") &&
                bl3.getInfo("pointing").Equals("right") &&
                bl4.getInfo("pointing").Equals("right"))
            {
                bl1.setInfo("pointing", "down");
                bl2.setInfo("pointing", "down");
                bl3.setInfo("pointing", "down");
                bl4.setInfo("pointing", "down");

                bl1.set("x", bl1.get("x"));
                bl1.set("y", bl1.get("y") + 100);
                bl2.set("x", bl2.get("x") + 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") - 50);
            }
            else if (bl1.getInfo("pointing").Equals("down") &&
                bl2.getInfo("pointing").Equals("down") &&
                bl3.getInfo("pointing").Equals("down") &&
                bl4.getInfo("pointing").Equals("down"))
            {
                bl1.setInfo("pointing", "left");
                bl2.setInfo("pointing", "left");
                bl3.setInfo("pointing", "left");
                bl4.setInfo("pointing", "left");

                bl1.set("x", bl1.get("x") - 100);
                bl1.set("y", bl1.get("y"));
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") + 50);
                bl4.set("x", bl4.get("x") + 50);
                bl4.set("y", bl4.get("y") + 50);
            }
            else if (bl1.getInfo("pointing").Equals("left") &&
                bl2.getInfo("pointing").Equals("left") &&
                bl3.getInfo("pointing").Equals("left") &&
                bl4.getInfo("pointing").Equals("left"))
            {
                bl1.setInfo("pointing", "up");
                bl2.setInfo("pointing", "up");
                bl3.setInfo("pointing", "up");
                bl4.setInfo("pointing", "up");

                bl1.set("x", bl1.get("x"));
                bl1.set("y", bl1.get("y") - 100);
                bl2.set("x", bl2.get("x") - 50);
                bl2.set("y", bl2.get("y") - 50);
                bl4.set("x", bl4.get("x") - 50);
                bl4.set("y", bl4.get("y") + 50);
            }
        }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        if (squares[squares.Count - 4].get("x") < 0 ||
            squares[squares.Count - 3].get("x") < 0 ||
            squares[squares.Count - 2].get("x") < 0 ||
            squares[squares.Count - 1].get("x") < 0)
        {
            wplayer.URL = "warn.wav";
            wplayer.controls.play();
            int move = 0;
            int min = squares[squares.Count - 4].get("x");
            if (squares[squares.Count - 3].get("x") < min)
            {
                min = squares[squares.Count - 3].get("x");
            }
            if (squares[squares.Count - 2].get("x") < min)
            {
                min = squares[squares.Count - 2].get("x");
            }
            if (squares[squares.Count - 1].get("x") < min)
            {
                min = squares[squares.Count - 1].get("x");
            }
            move = -1 * min;
            squares[squares.Count - 4].set("x", squares[squares.Count - 4].get("x") + move);
            squares[squares.Count - 3].set("x", squares[squares.Count - 3].get("x") + move);
            squares[squares.Count - 2].set("x", squares[squares.Count - 2].get("x") + move);
            squares[squares.Count - 1].set("x", squares[squares.Count - 1].get("x") + move);
        }
        else if (squares[squares.Count - 4].get("x") > 450 ||
            squares[squares.Count - 3].get("x") > 450 ||
            squares[squares.Count - 2].get("x") > 450 ||
            squares[squares.Count - 1].get("x") > 450)
        {
            wplayer.URL = "warn.wav";
            wplayer.controls.play();
            int move = 0;
            int max = squares[squares.Count - 4].get("x");
            if (squares[squares.Count - 3].get("x") > max)
            {
                max = squares[squares.Count - 3].get("x");
            }
            if (squares[squares.Count - 2].get("x") > max)
            {
                max = squares[squares.Count - 2].get("x");
            }
            if (squares[squares.Count - 1].get("x") > max)
            {
                max = squares[squares.Count - 1].get("x");
            }
            move = -1 * (max - 450);
            squares[squares.Count - 4].set("x", squares[squares.Count - 4].get("x") + move);
            squares[squares.Count - 3].set("x", squares[squares.Count - 3].get("x") + move);
            squares[squares.Count - 2].set("x", squares[squares.Count - 2].get("x") + move);
            squares[squares.Count - 1].set("x", squares[squares.Count - 1].get("x") + move);
        }
        if (isStacked()||squares[squares.Count - 4].get("y") > 600 || squares[squares.Count - 3].get("y") > 600 ||
            squares[squares.Count - 2].get("y") > 600 || squares[squares.Count - 1].get("y") > 600)
        {
            wplayer.URL = "dingdong.wav";
            wplayer.controls.play();
            addBrandNewBlocks();
            clearLine();
        }
        else
        {
            bool stacked = false;
            for (int i = squares.Count - 4; i < squares.Count; i++)
            {
                for (int j = 0; squares.Count != 4 && j < squares.Count - 4; j++)
                {
                    if (squares[i].get("x") == squares[j].get("x") && squares[i].get("y") + 50 == squares[j].get("y"))
                    {
                        stacked = true;
                    }
                }
            }
            if (stacked&&(squares[squares.Count - 4].get("y") < 60 || squares[squares.Count - 3].get("y") < 60 ||
            squares[squares.Count - 2].get("y") < 60 || squares[squares.Count - 1].get("y") < 60))
            {
                wplayer.URL = "stack.wav";
                wplayer.controls.play();
                squares.Clear();
                addBrandNewBlocks();
                score = 0;
                frame.Text = "Score: 0";
            }
            else
            {
                down();
            }    
        }

        RefreshMyForm();
    }

    private void RefreshMyForm()
    {

        frame.Refresh();
    
    }

    private bool isStacked()
    {
        for (int i = squares.Count - 4; i < squares.Count; i++)
        {
            for (int j = 0; squares.Count != 4 && j < squares.Count - 4; j++)
            {
                if (!(squares[squares.Count - 4].get("y") < 60 || squares[squares.Count - 3].get("y") < 60 ||
            squares[squares.Count - 2].get("y") < 60 || squares[squares.Count - 1].get("y") < 60)&&(squares[i].get("x") == squares[j].get("x") && squares[i].get("y") + 50 == squares[j].get("y")))
                {
                    wplayer.URL = "stack.wav";
                    wplayer.controls.play();
                    return true;
                }
            }
        }
        return false;
    }

    static void Main(String[] args)
    {
        Titrus titrus = new Titrus();
        Application.Run(titrus.frame);
    }

    public void down()
    {
        if (isStacked() || squares[squares.Count - 4].get("y") > 600 || squares[squares.Count - 3].get("y") > 600 ||
            squares[squares.Count - 2].get("y") > 600 || squares[squares.Count - 1].get("y") > 600)
        {
        }
        else
        {
            for (int index = squares.Count - 4; index < squares.Count; index++)
            {

                squares[index].set("y", squares[index].get("y") + 50);

            }
        }
    }

    public void right()
    {
        if (!isJuxtaposedLeft())
        {
            for (int index = squares.Count - 4; index < squares.Count; index++)
            {

                squares[index].set("x", squares[index].get("x") + 50);

            }
        }
    }

    public void left()
    {
        if (!isJuxtaposedRight())
        {
            for (int index = squares.Count - 4; index < squares.Count; index++)
            {
                squares[index].set("x", squares[index].get("x") - 50);
            }
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        var g = panel.CreateGraphics();
        
        Image bg = gibg.GetNextFrame();
        if (bg != null)
        {
            g.DrawImage(bg, 0, 0, panel.Width, panel.Height);
        }

        Size sizeOfBlock = new Size(50, 50);
        Image block = gi.GetNextFrame();

        if (block != null)
        {
            var bmp = new Bitmap(block, sizeOfBlock);

            bmp.MakeTransparent(Color.Transparent);
            for (int index = 0; index < squares.Count; index++)
            {
                g.DrawImage(bmp, squares[index].get("x"),
                    squares[index].get("y"));
            }
        }
    }
}