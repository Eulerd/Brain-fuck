using System;
using System.Collections.Generic;
using System.Linq;

namespace Brain_fuck
{
    class BrainF_ck
    {
        /// <summary>
        /// 仮想メモリ
        /// </summary>
        private List<byte> memory;

        /// <summary>
        /// BrainF_ckコード
        /// </summary>
        private readonly string bfCode;
        
        /// <summary>
        /// 入力データ
        /// </summary>
        private Queue<byte> inputData;

        /// <summary>
        /// メモリポインタ
        /// </summary>
        private int memoryPtr;

        /// <summary>
        /// コードポインタ
        /// </summary>
        private int codePtr;

        /// <summary>
        /// 括弧同士の対応データ
        /// </summary>
        private Dictionary<int, int> brankets;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="code">BrainF*ckのコード</param>
        /// <param name="inputs">BrainF*ckのコードに渡させる入力情報</param>
        public BrainF_ck(string code, string inputs)
        {
            CheckBranketsCount(code);

            brankets = new Dictionary<int, int>();
            inputData = new Queue<byte>();
            memory = new List<byte>();

            bfCode = code;

            // 入力データをセット
            foreach(char input in inputs)
            {
                inputData.Enqueue((byte)input);
            }
            SetLoopSymbol();

            memory.Clear();
            memory.Add(0);
            memoryPtr = 0;
            codePtr = 0;

            IsOutputUpdate = false;
            IsEnded = false;
            OutputData = '\0';
        }
        
        /// <summary>
        /// メモリの状態を文字列で取得
        /// </summary>
        /// <returns>メモリの状態</returns>
        public string GetMemoryState()
        {
            string memoryState = "";

            for(int i = 0;i < memory.Count();i++)
            {
                if(i > 0)
                    memoryState += " ";

                if (i == memoryPtr)
                    memoryState += "[";

                memoryState += memory[i].ToString("D3");

                if (i == memoryPtr)
                    memoryState += "]";
            }

            return memoryState;
        }
        
        /// <summary>
        /// 次のステップ
        /// </summary>
        public void NextStep()
        {
            if (bfCode.Length <= codePtr)
            {
                IsEnded = true; 
                return;
            }

            if (IsOutputUpdate)
                IsOutputUpdate = false;

            switch (bfCode[codePtr])
            {
                case '+':
                    memory[memoryPtr]++;
                    break;

                case '-':
                    memory[memoryPtr]--;
                    break;

                case '>':
                    if (memory.Count() - 1 <= memoryPtr)
                        memory.Add(0);

                    memoryPtr++;
                    break;

                case '<':
                    if (memoryPtr <= 0)
                        throw new OutOfMemoryException("負数のメモリを参照しようとしました");

                    memoryPtr--;
                    break;

                case '.':
                    IsOutputUpdate = true;
                    OutputData = (char)memory[memoryPtr];
                    break;

                case ',':
                    memory[memoryPtr] = inputData.Dequeue();
                    break;

                case '[':
                    if (memory[memoryPtr] == 0)
                        codePtr = brankets[codePtr];
                    break;

                case ']':
                    if (memory[memoryPtr] != 0)
                        codePtr = brankets[codePtr];
                    break;
            }

            codePtr++;
        }

        /// <summary>
        /// 括弧の過不足がないか確認
        /// </summary>
        private void CheckBranketsCount(string code)
        {
            bool IsSameCount = true;
            foreach(char ch in code)
            {
                switch (ch)
                {
                    case '[':
                    case ']':
                        IsSameCount = !IsSameCount;
                        break;
                }
            }

            if (!IsSameCount)
                throw new ArgumentException("括弧の数が間違っています。");
        }

        /// <summary>
        /// 括弧の対応関係を設定する
        /// </summary>
        private void SetLoopSymbol()
        {
            Stack<int> openBranketsStack = new Stack<int>();

            for(int i = 0;i < CodeLength;i++)
            {
                switch(bfCode[i])
                {
                    case '[':
                        openBranketsStack.Push(i);
                        break;

                    case ']':
                        int num = openBranketsStack.Pop();
                        brankets.Add(num, i);
                        brankets.Add(i, num);
                        break;
                }
            }
        }
        
        /// <summary>
        /// 終了したか
        /// </summary>
        public bool IsEnded { get; private set; }

        /// <summary>
        /// 出力データが更新されたか
        /// </summary>
        public bool IsOutputUpdate { get; private set; }

        /// <summary>
        /// 出力データ
        /// </summary>
        public char OutputData { get; private set; }

        /// <summary>
        /// コードの長さ
        /// </summary>
        public int CodeLength
        {
            get { return bfCode.Length; }
        }
    }
}
