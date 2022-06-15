from operator import truediv


class Node:
    def __init__(self, info):
        self.data = info
        self.left = None
        self.right = None

    def __str__(self):
        return str(self.data)


class BinarySearchTree:
    def __init__(self):
        self.root = None

    def create(self, val):
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root

            while True:
                if val < current.data:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.data:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break


# Enter your code here. Read input from STDIN. Print output to STDOUT
'''
class Node:
      def __init__(self,info): 
          self.data = data  
          self.left = None  
          self.right = None 
           

       // this is a node of the tree , which contains info as data, left , right
'''

'''
this algo checks if any node on left should be greater
'''
def bst(node, min, max):

    if(node is None):
        return True

    if(node.data <= min or node.data >= max):
        return False

    return bst(node.left, min, node.data) and bst(node.right, node.data, max)


def checkBST(root):
    return bst(root, -100000, 100000)


if __name__ == "__main__":

    tree = BinarySearchTree()
    t = int(7)

    arr = list(map(int, "1 2 4 3 5 6 7".split()))

    for i in range(t):
        tree.create(arr[i])

    print("Yes" if checkBST(tree.root) else "No")
