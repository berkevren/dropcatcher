using System;
using System.IO;
using System.Linq;

namespace DropCatcher
{
    public class FileLogger
    {
        private readonly string path;

        public FileLogger(string path)
        {
            this.path = path;
        }

        public bool WriteFileIfNewProductIsFound(string newProducts, int numberOfProductsOnPage)
        {
            string[] fileContent;
            string[] latestProducts;


            if (this.TryReadFile(out fileContent)
                && fileContent.Length > numberOfProductsOnPage)
            {
                latestProducts = fileContent.Skip(fileContent.Length - numberOfProductsOnPage).ToArray(); // there are 4 products on the page
                var newProductsWithoutFirstLine = this.RemoveFirstLine(newProducts); // remove date

                for (int i = 0; i < latestProducts.Length; i++)
                {
                    if (i >= newProductsWithoutFirstLine.Length)
                    {
                        break;
                    }

                    if (!latestProducts[i].Equals(newProductsWithoutFirstLine[i]))
                    {
                        newProducts = "\n\n" + newProducts;
                        this.WriteToFile(newProducts);
                        return true;
                    }
                }

                return false;
            }

            this.WriteToFile(newProducts);
            return true;
        }

        public void WriteToFile(string products)
        {
            File.AppendAllText(this.path, products);
        }

        private bool TryReadFile(out string[] fileContent)
        {
            try
            {
                fileContent = File.ReadAllLines(this.path);
                return true;
            }
            catch
            {
                fileContent = Array.Empty<string>();
                return false;
            }
        }

        private string[] RemoveFirstLine(string fileContents)
        {
            string[] lines = fileContents
                .Split(Environment.NewLine.ToCharArray())
                .Skip(1)
                .ToArray();

            return lines;
        }
    }
}
