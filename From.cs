using System.Windows.Forms;

class From : Form
{
    private Titrus _titrus = null;

    public From(Titrus titrus)
    {
        this._titrus = titrus;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Left)
        {
            _titrus.left();
            Refresh();
            return true;
        }
        else if (keyData == Keys.Up)
        {
            _titrus.rotate();
            Refresh();
            return true;
        }
        else if (keyData == Keys.Right)
        {
            _titrus.right();
            Refresh();
            return true;
        }
        else if (keyData == Keys.Down)
        {
            _titrus.down();
            Refresh();
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

}
