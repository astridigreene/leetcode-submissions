class Solution:
    def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
        seen = defaultdict(list)
        for i in range(len(strs)):
            temp = ''.join(sorted(strs[i]))
            seen[temp].append(strs[i])
        return list(seen.values())
                
