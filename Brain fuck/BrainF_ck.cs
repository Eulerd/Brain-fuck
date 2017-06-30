using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain_fuck
{
    class BrainF_ck
    {
        /// <summary>
        /// 仮想メモリ
        /// </summary>
        List<byte> memory;

        /// <summary>
        /// BrainF_ckコード
        /// </summary>
        readonly string bfCode;
        
        /// <summary>
        /// 入力データ
        /// </summary>
        Queue<byte> inputData;

        /// <summary>
        /// メモリポインタ
        /// </summary>
        int memoryPtr;

        /// <summary>
        /// コードポインタ
        /// </summary>
        int codePtr;

        /// <summary>
        /// 括弧同士の対応データ
        /// </summary>
        Dictionary<int, int> brankets;

        /// <summary>
        /// コンストラクタ
        /// </summary>
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

            memory.Clear();
            memory.Add(0);
            memoryPtr = 0;
            codePtr = 0;

            IsOutputUpdate = false;
            OutputData = '\0';
        }

        /// <summary>
        /// 括弧の過不足がないか確認
        /// </summary>
        void CheckBranketsCount(string code)
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
        void SetLoopSymbol()
        {
            int left = 0;
            int right = bfCode.Length - 1;

            while(left < right)
            {
                if(bfCode[left] == '[')
                {
                    while(left < right)
                    {
                        if(bfCode[right] == ']')
                        {
                            brankets.Add(left, right);
                            brankets.Add(right, left);
                            break;
                        }

                        right--;
                    }
                }

                left++;
            }
            
        }

        /// <summary>
        /// 次のステップ
        /// </summary>
        void NextStep()
        {
            if (bfCode.Length <= codePtr)
                throw new IndexOutOfRangeException("このコードは終了しています。");

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
                        memoryPtr = brankets[memoryPtr];
                    else
                        memoryPtr++;
                    break;

                case ']':
                    memoryPtr = brankets[memoryPtr];
                    break;
            }

            codePtr++;
        }

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
