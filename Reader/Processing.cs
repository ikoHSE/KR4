using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Reader {
    public class Processing: IEnumerable<Data> {
        public Processing(string p) {
            path = p;
        }

        private string path;

        IEnumerator<Data> IEnumerable<Data>.GetEnumerator() {
            return new ProcessingEnum(path);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return new ProcessingEnum(path);
        }

        class ProcessingEnum: IEnumerator<Data> {
            StreamReader reader;
            string path;
            internal ProcessingEnum(string p) {
                path = p;
                try {
                    reader = new StreamReader(p);
                } catch {
                    throw new ArgumentException();
                }
            }

            private Data last;

            Data IEnumerator<Data>.Current => last;

            object IEnumerator.Current => last;

            bool IEnumerator.MoveNext() {
                if (reader == null) {
                    throw new InvalidOperationException();
                }
                var l = reader.ReadLine();
                if (l == null) {
                    reader.Close();
                    reader = null;
                    return false;
                }
                last = new Data(l.Trim());
                return last != null;
            }

            void IEnumerator.Reset() {
                try {
                    reader = new StreamReader(path);
                } catch {
                    throw new ArgumentException();
                }
            }

            void IDisposable.Dispose() {
            }
        }
    }
}
