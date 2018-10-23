class Block
{
    private int y;
    private int x;
    private string pointing;
    private string type;
    public string getInfo(string kind)
    {
        return "pointing".Equals(kind) ? this.pointing : ("type".Equals(kind) ? this.type : null);
    }
    public int set(string position, int val)
    {
        return "x".Equals(position) ? this.x = val : ("y".Equals(position) ? this.y = val : val);
    }
    public int get(string position)
    {
        return "x".Equals(position) ? this.x : ("y".Equals(position) ? this.y : -1);
    }
    public void setInfo(string kind, string val)
    {
        if ("pointing".Equals(kind))
        {
            this.pointing = val;
        }
        else
        {
            if ("type".Equals(kind))
            {
                this.type = val;
            }
        }
    }
}
