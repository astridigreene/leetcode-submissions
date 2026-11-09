# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def isValidBST(self, root: TreeNode | None) -> bool:
        '''

        left node < root and right node > root: return True
        null return True

        basecase:
        - if nullptr: return True
        - if left ptr is not null and >= root or right ptr is not null and <= root: return False
        - return (dfs(left) and dfs(right))

        dfs(lower_bound, upper_bound, root):
        - bounds(-infinity, infinity)
        - left->(-infinity, root.left.val)
        - right->(root.right.val, infinity)
        if not root: return True
        if root.val <= lower_bound or root.val >= upper_bound: return False
        return (dfs(lower_bound, root.val, root.left) and dfs(root.val, upper_bound, root.right))



        '''


        def dfs(lower, upper, node):
            # print(node.val)
            if not node:
                return True
            if node.val <= lower or node.val >= upper:
                print(f"{node.val}, {lower}, {upper}")
                return False
            return (dfs(lower, node.val, node.left) and dfs(node.val, upper, node.right))
        
        return dfs(float('-inf'), float('inf'), root)

        

        '''

            5
        4        6
                3 7

        '''